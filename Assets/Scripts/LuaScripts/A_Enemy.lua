--Enemy1的控制类

-- --获取怪物数据
-- require("A_LevelSettings")
-- --游戏结算脚本
-- require("A_SettlementCtrl")

--设置单例
A_Enemy={
   --物体自身
   gameObject=nil,
   --调用游戏工具类
   tool=GameTool.GetInstance(),
   --设置Enemy1的属性参数
   LevelData=A_LevelSettings.GetInstance(),
   --敌人血条Canvas
   HpUI=nil,
   --敌人血条Slider
   HpSlider=nil,
   --当前敌人的实例
   EnemyObj=nil,
   --总血量
   TotalHp=nil,
   --当前血量
   Hp=nil,
   --目标位置
   GoalPosition=nil,
   --自身索引
   IndexSelf=nil,
   --动画状态机
   EnemyAnimator=nil,
   --死亡掉落钱数
   GetMoney=nil,
   --延时计数参数
   IsDelete=nil,
   --死亡等待时间
   DeadRateTime=1.5,
   --已经等待时间
   DeadTimer=nil,
   
   --是否是无尽模式
   IsNoEnd=nil
}

A_Enemy.__index=A_Enemy
function A_Enemy:New(Obj,HpCanvas,HpSetting,speed,getMoney)
   local temp = {}
   setmetatable(temp,A_Enemy)
   --工具类
   temp.tool=GameTool.GetInstance()
   --初始化等待时间
   temp.DeadTimer=0
   --初始化死亡判断参数
   temp.IsDelete=false
   --拿到物体实例
   temp.gameObject=Obj
   --敌人类型
   temp.GetMoney=getMoney
   --拿到血条UI
   temp.Canvas=HpCanvas
   --拿到血量
   temp.TotalHp=HpSetting
   temp.Hp=HpSetting
   --默认不是无尽模式
   temp.IsNoEnd=false
   --目标位置
   temp.GoalPosition=CSU.GameObject.Find("EndPosition").transform.position
   --设置移动速度
   Obj:GetComponent(typeof(CSU.AI.NavMeshAgent)).speed=speed
   --找到目标位置并设置
   Obj:GetComponent(typeof(CSU.AI.NavMeshAgent)).destination=temp.GoalPosition
   --拿到动画状态机
   temp.EnemyAnimator=temp.gameObject:GetComponent(typeof(CSU.Animator))
   return temp
end




function A_Enemy:Update()
  --保持血条跟随
  if(self.gameObject~=nil) then
     self.Canvas.transform.position=self.gameObject.transform.position
     self.tool:SliderUp(self.Canvas)
     --如果到达目的地，游戏失败
     if(self.tool:IsFail(self.gameObject,self.GoalPosition)) then
        A_CtrlMgr.PrefabPool:Put(self.gameObject)
        
        A_SettlementCtrl.GetInstance():Failed()
     end

     --检测是否到了删除时间
     if(self.IsDelete==true) then
         self.DeadTimer=self.DeadTimer+CSU.Time.deltaTime
         if self.DeadTimer>=1 then
            A_CtrlMgr.PrefabPool:PutEnemy(self.gameObject)
            --停止刷新其update
            A_EnemyManager:Remove(self)
         end
     end
  end
end



--受到伤害，被子弹所调用
function A_Enemy:Takedamage(damage)
   --扣血
   self.Hp=self.Hp-damage
   --更改血条显示
   local HpSlider=self.Canvas.transform:Find("HpSlider"):GetComponent("UnityEngine.UI.Slider")
   HpSlider.value=self.Hp/self.TotalHp
   --血量为0，敌人死亡
   if(self.Hp<=0) then
      if self.IsDelete==false then
         self:Die()
      end
   end
end



--敌人死亡
function A_Enemy:Die()
   --在全局敌人列表中移除自身
   A_EnemySpawnerCtrl:UpdateALLEnemySpawnered(self.gameObject)
   --加金币
   A_BuildManagerCtrl.ChanageMoney(-self.GetMoney)
   --播放死亡动画
   self.EnemyAnimator:SetBool("IsDeath",true)
   --删除敌人物体和身上的血条
   self.gameObject:GetComponent(typeof(CSU.AI.NavMeshAgent)).speed=0
   --回收血条UI
   A_CtrlMgr.PrefabPool:PutUI(self.Canvas)
   if self.IsNoEnd==false then
      --活着的敌人数量减1
      A_EnemySpawnerCtrl.EnemyAlive=A_EnemySpawnerCtrl.EnemyAlive-1
   end
   --触发死亡事件
   self.IsDelete=true
end