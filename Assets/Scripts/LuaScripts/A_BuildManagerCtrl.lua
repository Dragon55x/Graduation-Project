--建造管理类



--模拟类
A_BuildManagerCtrl={}
local this=A_BuildManagerCtrl

-- --调用DefenseManager脚本
-- local DTManager=CS.PFW.DefenseManager
-- local abDTObj=DTManager.GetInstance()
--调用游戏工具类
local tool=GameTool.GetInstance()
-------------------建造信息----------------------------

--获取关卡信息
local levelData=A_LevelSettings.GetInstance()
--当前关卡
local Level
--地面列表
GroundData={}
--炮塔列表
local TurretUIList={}
local GroundDatatmp={}
--监听函数列表
local ListenerList={}
--被选中的炮塔
local SelectedTurret=nil

--找到Canvas
local  UIobj=CSU.GameObject.Find("DefenseListUIForm(Clone)")

--升级UI
local UpgradeUI=nil
--升级UI是否打开
local IsOpenUI=false
--中间变量
local index = 0
--当前操作的地块
local cubeNameUI=nil

--初始化监听函数
ListenerList["DefenseA"]=function () SelectedTurret="DefenseA" end
ListenerList["DefenseB"]=function () SelectedTurret="DefenseB" end
ListenerList["DefenseC"]=function () SelectedTurret="DefenseC" end
ListenerList["DefenseD"]=function () SelectedTurret="DefenseD" end

function A_BuildManagerCtrl.Awake()
   --记录地面信息
   this.ReadGround()
end

function A_BuildManagerCtrl.Start(obj)
    --print("开始处理建造逻辑")    
    --当前关卡信息
    Level=levelData[obj.tag]
    --拿到升级UI
    local father=CSU.GameObject.Find("GameUI")
    UpgradeUI=CS.TFW.UnityHelper.FindTheChildNode(father,"UpgradeUI")
    --调用添加监听函数 
    this.AddListener(Level.turret)
    
    --初始化金币数并发出通知
    A_CtrlMgr.Money.number=Level.DefaultMoney
    A_CtrlMgr.Money:Notify()
end

--初始化所有地面位置为无炮塔，未升级
function A_BuildManagerCtrl.ReadGround()
   local ground=CSU.GameObject.Find("CubeManager")
   GroundDatatmp=tool:GetChildName(ground,GroundDatatmp)
   for i,child in pairs(GroundDatatmp) do
      GroundData[child]={preturret=nil,preturrettype=nil,isUpgraded=false}
   end
end


--根据实际UI中炮塔的数量与类型添加监听事件
function A_BuildManagerCtrl.AddListener(levelDataTurret)

   --根据关卡数据检索UI上对应的按钮
   for i,child in pairs(levelDataTurret) do
      TurretUIList[i]=UIobj.transform:Find(child)
      TurretUIList[i]=TurretUIList[i]:GetComponent("UnityEngine.UI.Button") 
   end

   --添加按钮事件监听
   for i,listner in pairs(TurretUIList) do
      listner.onClick:AddListener(ListenerList[listner.name])
   end
   
   --升级、拆除UI按钮监听
   UpgradeUI:Find("Upgrade"):GetComponent("UnityEngine.UI.Button").onClick:AddListener(this.UpgradeTurret)
   UpgradeUI:Find("Delete"):GetComponent("UnityEngine.UI.Button").onClick:AddListener(this.DeleteTurret)
  -- print("按钮事件监听添加成功")
end



-----------检测玩家操作------------------------
function A_BuildManagerCtrl.Update()
   --如果检测到鼠标点击且未点击到UI，执行炮塔建造
   local isover=tool:IsOverGameObject()
   --鼠标点击且不在UI上
   if(CSU.Input.GetMouseButtonDown(0) and isover==false) then
        --是否与地图产生碰撞
        local isCollider=tool:isCollider()
        --存储碰撞信息
        local HitInfro=tool:HitInfro()
        --如果点击了砖块
        if(isCollider==true and HitInfro.collider.gameObject.layer==8) then
            --找到点击的砖块名字
            local cubeName=HitInfro.collider.gameObject.name
            --print("点击了砖块： "..cubeName)
            --如果此砖块上无炮塔，且已经选择了一个炮塔
            if(GroundData[cubeName].preturret==nil and SelectedTurret~=nil) then
               -- print(A_CtrlMgr.Money.number)
               -- print(Level.turretAttributes[SelectedTurret].cost)
               --检测金币余额
               if(A_CtrlMgr.Money.number>=Level.turretAttributes[SelectedTurret].cost) then
                  --扣钱qwq
                  this.ChanageMoney(Level.turretAttributes[SelectedTurret].cost)
                  --建造炮塔
                  this.BuildTurret(SelectedTurret,cubeName) 
               else 
                  --没钱了你
                  print("没钱了！！")
               end
               --print("选择的炮塔："..SelectedTurret.."   价格："..Level.turretAttributes[SelectedTurret].cost.."剩余金币"..A_CtrlMgr.Money.number)
            --已经有炮塔
            elseif(GroundData[cubeName].preturret~=nil) then
               --如果点击的位置有塔、和选中的炮塔一样、升级UI已经出现，则隐藏
               if SelectedTurret==GroundData[cubeName].preturrettype and IsOpenUI==true then
                  this.HideUpGradeUI()
               else
                  --打开升级UI
                  this.ShowUpGradeUI(cubeName)
               end
            end
        end
   end
end

--金币更改
function A_BuildManagerCtrl.ChanageMoney(changeMoney)
   A_CtrlMgr.Money.number=A_CtrlMgr.Money.number-changeMoney
   A_CtrlMgr.Money:Notify()
end

--炮塔建造
function A_BuildManagerCtrl.BuildTurret(SelectedTurret,cubeName)
   --找到选中的地面
   local cube =CSU.GameObject.Find(cubeName)
   --获取炮塔要生成的位置
   local position=cube.transform.position
   --加载炮塔预制体
   local tmpObj=A_CtrlMgr.abDTObj:PrefabAB(SelectedTurret)
   -- --生成并记录
   GroundData[cubeName].preturret=CSU.GameObject.Instantiate(tmpObj)
   --炮塔上移
   GroundData[cubeName].preturret.transform.position=tool:UpPosition(position)
   --当前cube上的炮塔类型
   GroundData[cubeName].preturrettype=SelectedTurret
   --实例化炮塔类
   local TurretObj=A_Turret:New(GroundData[cubeName].preturret,SelectedTurret,Level)
   index = index + 1
   --记录该炮塔的索引
   TurretObj.IndexSelf=index
   --存入炮塔列表
   A_TurretManager.DefenseList[index] = TurretObj
end


--------------------------------------升级UI的行为逻辑-------------------------------------------

--打开升级UI
function A_BuildManagerCtrl.ShowUpGradeUI(cubeName)
   --找到选中的地面
   local cube =CSU.GameObject.Find(cubeName)
   --获取升级UI要出现的位置的位置
   local UIposition=cube.transform.position
   --打开升级UI
   UpgradeUI.gameObject:SetActive(true)
   --设置升级UI位置
   tool:UpgradeUI_Up(UIposition,UpgradeUI)
   --UI已经打开
   IsOpenUI=true
   --赋值被操作的地块
   cubeNameUI=cubeName
   --位置升高
end
--隐藏升级UI
function A_BuildManagerCtrl.HideUpGradeUI()
   UpgradeUI.gameObject:SetActive(false)
   IsOpenUI=false
   --建造操作重置（即不会点一下UI，就可以一直建塔）
   --SelectedTurret=nil
end


----------------俩按钮的事件响应------------
--炮塔升级按钮
function A_BuildManagerCtrl.UpgradeTurret()
   --如果当前钱多于升级所需钱
   if A_CtrlMgr.Money.number>=Level.turretAttributes[GroundData[cubeNameUI].preturrettype].UpgradeCost and GroundData[cubeNameUI].isUpgraded==false then
      --记录升级状态
      GroundData[cubeNameUI].isUpgraded=true
      --打开升级后的Buff特效
      CS.TFW.UnityHelper.FindTheChildNode(GroundData[cubeNameUI].preturret,"Partical").gameObject:SetActive(true)
      --扣钱
      this.ChanageMoney(Level.turretAttributes[GroundData[cubeNameUI].preturrettype].UpgradeCost)
      --找到这个炮塔的类并调用刷新数据函数
      for i,v in pairs(A_TurretManager.DefenseList) do
         if(v.gameObject==GroundData[cubeNameUI].preturret) then
            --调用其刷新数据方法
            v:UpdateData()
            break
         end
      end
   elseif GroundData[cubeNameUI].isUpgraded==true then
      --print("不能再升级了")
   else
      --print("没钱升级了！！！")
   end
   --关闭升级UI
   this.HideUpGradeUI()
   --建造操作重置（即不会点一下UI，就可以一直建塔）
   SelectedTurret=nil
end

--炮塔拆除按钮
function A_BuildManagerCtrl.DeleteTurret()
   --删除炮塔物体
   tool:DestroyNow(GroundData[cubeNameUI].preturret,0)
   --返还一半的金币
   this.ChanageMoney(math.floor(-Level.turretAttributes[GroundData[cubeNameUI].preturrettype].cost/2))
   --关闭升级UI
   this.HideUpGradeUI()
   --停止刷新其Update
   for i,v in pairs(A_TurretManager.DefenseList) do
      if(v.gameObject==GroundData[cubeNameUI].preturret) then
         A_TurretManager:Remove(v)
      end
   end
   --地块复原
   GroundData[cubeNameUI].preturret=nil
   GroundData[cubeNameUI].preturrettype=nil
   GroundData[cubeNameUI].isUpgraded=false
end
---------------------------------------------------------------------------------