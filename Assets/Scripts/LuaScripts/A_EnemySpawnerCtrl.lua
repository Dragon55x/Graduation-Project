--敌人生成管理类

----------------引用脚本-----------------------
-- --怪物生成逻辑
-- require("TestSysDefine")
-- --获取关卡数据
-- require("A_LevelSettings")
-- --游戏结算脚本
-- require("A_SettlementCtrl")


--模拟类
A_EnemySpawnerCtrl={
   --活着的敌人,用于判断游戏胜利与否
   EnemyAlive=nil,
   --生成的敌人列表
   EnemyListSpawnered={},
   --已经生成的敌人数量
   Enemycount=nil
}
local this=A_EnemySpawnerCtrl

--活着的敌人,用于判断游戏胜利与否
this.EnemyAlive=0
--生成的敌人列表
this.EnemyListSpawnered={}
--已经生成的敌人数量
this.Enemycount=0

--调用游戏工具类
local tool=GameTool.GetInstance()

----------------关于敌人的数据等------------------
--拿到敌人加载的cs脚本
-- local DTManager=CS.PFW.DefenseManager
-- local abDTObj=DTManager.GetInstance()
--拿到敌人数据的实例
local levelData=A_LevelSettings.GetInstance()
--敌人列表

--存放敌人预制体
local tempObj={}
--计数参数
local Index=0
--已经等待时间
local enemy_timer
--波次间隔已经等待时间
local wave_timer
--生成间隔
local EnemyRateTime
--同波次敌人生成间隔
local WaveRateTime
--要生成的敌人数量
local EnemyCount
--这一波已经生成的敌人数量
local EnemycountThisWave
--用于判断是否第一次等于0
local IsFirstEqualZero=true
--敌人生成位置
local EnemyPosition

--关卡名称
local LevelName
--关卡信息
local Level
--当前波次
local WaveCountCurrent
--波数
local WaveCount
--敌人结算脚本的实例
local settlementCtrl=A_SettlementCtrl.GetInstance()


--用于无尽模式下判断敌人类型
local IsEnemy1=true
local DefaultHp1
local DefaultHp2
function A_EnemySpawnerCtrl.GetInstance()
	print("进入敌人生成管理类")
    return this
end

--------------------------------------敌人生成逻辑-------------------------------------------
function A_EnemySpawnerCtrl.Awake()
   --------------------------------初始化、清空------------------------------
   --活着的敌人,用于判断游戏胜利与否
   this.EnemyAlive=0
   --生成的敌人列表
   this.EnemyListSpawnered={}
   --已经生成的敌人数量
   this.Enemycount=0
   --敌人生成位置
   this.EnemyPosition=nil
   --这一波已经生成的敌人数量
   EnemycountThisWave=0
   --波数
   WaveCountCurrent=1
end

function A_EnemySpawnerCtrl.Start(obj)
   WaveCount=0
   --获取当前关卡
   Level=levelData[obj.tag]
   LevelName=obj.tag
   local levelspawnerpos=Level.enemySpawmerPosition
   --敌人出生地
   EnemyPosition=CSU.GameObject.Find(levelspawnerpos)
   --间隔时间
   EnemyRateTime=Level.EnemyRateTime
   --已经等待时间
   enemy_timer=0

   --无尽模式下怪物初始血量
   if obj.tag=="Level_NoEnd" then
      DefaultHp1=Level.enemyAttributes["A_Enemy1"].Hp
      DefaultHp2=Level.enemyAttributes["A_Enemy2"].Hp
   else
      WaveRateTime=Level.WaveRateTime
      wave_timer=0
      --敌人数量
      EnemyCount=Level.AllenemyCounts
      --读取敌人种类进行加载 并读取波次数量 
      local tempcount=0
      for i,wave in pairs(Level.enemy) do
          tempcount=tempcount+1
      end
      --波次数量
      WaveCount=tempcount   
   
   end
end



function A_EnemySpawnerCtrl.Update()

   --前四关
   if(LevelName~="Level_NoEnd") then
      --print("需要生成敌人数量： "..EnemyCount.."   已经生成的数量： "..this.Enemycount.."   当前活着的敌人："..this.EnemyAlive)
      --当前波次小于总波数
      if(WaveCountCurrent<=WaveCount and this.Enemycount<EnemyCount) then
         --生成波次 
         this.Wave(Level.enemy[WaveCountCurrent])
      end
         --如果场上敌人为0且全部生成完
      if this.EnemyAlive==0 and this.Enemycount==EnemyCount then
         A_SettlementCtrl.GetInstance():Win()
      end
   --无尽模式
   else
      enemy_timer=enemy_timer+CSU.Time.deltaTime
      if(enemy_timer>=EnemyRateTime) then
         --执行生成函数，轮流生成
         if IsEnemy1==true then
            this.ShengChengNoEnd("A_Enemy1",DefaultHp1)
            --血量递增
            DefaultHp1=DefaultHp1+20
            enemy_timer=0
            IsEnemy1=false
         else
            this.ShengChengNoEnd("A_Enemy2",DefaultHp2)
            --血量递增
            DefaultHp2=DefaultHp2+20
            enemy_timer=0
            IsEnemy1=true
         end
      end 
   end
end

--波次生成
function A_EnemySpawnerCtrl.Wave(wave)
   --如果这一波没生成完
   if(EnemycountThisWave<wave.count) then
      --等待生成间隔
      enemy_timer=enemy_timer+CSU.Time.deltaTime
       if(enemy_timer>=EnemyRateTime) then
         --执行生成函数
         this.ShengCheng(wave)
         enemy_timer=0
      end
   --这一波已经生成完了
   else
      wave_timer=wave_timer+CSU.Time.deltaTime
      if(wave_timer>=WaveRateTime) then 
         --当前波次+1，跳到下一波次
         WaveCountCurrent=WaveCountCurrent+1
         --每波已生成敌人归0
         EnemycountThisWave=0
         --波次等待时间归0
         wave_timer=0
      end
   end

   --print("A_EnemySpawener106行  场上敌人：  "..this.EnemyAlive.."已经生成的敌人：  "..Enemycount.."需要生成：  "..EnemyCount)

  
end
--生成敌人
function A_EnemySpawnerCtrl.ShengCheng(wave)
   -- local enemyObj=CSU.Object.Instantiate(A_CtrlMgr.abDTObj:PrefabAB(wave.type),EnemyPosition.transform.position,CSU.Quaternion.identity)
   -- local enemySliderCanvas=CSU.Object.Instantiate(A_CtrlMgr.abDTObj:PrefabAB("Hp"),EnemyPosition.transform.position,CSU.Quaternion.identity)
   
   --向对象池中获取物体
   local enemyObj=A_CtrlMgr.PrefabPool:GetEnemy(wave.type,EnemyPosition)
   local enemySliderCanvas=A_CtrlMgr.PrefabPool:GetEnemy("Hp",EnemyPosition)

   --存入全局敌人列表
   table.insert(this.EnemyListSpawnered,enemyObj)
   --实例化敌人行为类, 传入对应血条UI，总血量，初始化当前血量,速度,敌人类型
   local EnemyObj=A_Enemy:New(enemyObj,enemySliderCanvas,Level.enemyAttributes[wave.type].Hp,wave.speed,Level.enemyAttributes[wave.type].getMoney)
   --存入行为类列表
   Index=Index+1
   --存入索引
   EnemyObj.IndexSelf=Index
   --存入敌人Update管理实例列表
   A_EnemyManager.EnemySelfList[Index]=EnemyObj

   --已经生成的敌人数量+1
   this.Enemycount=this.Enemycount+1
   --当前活着的敌人数量+1
   this.EnemyAlive=this.EnemyAlive+1
   --这一波生成的敌人+1
   EnemycountThisWave=EnemycountThisWave+1

end

--无尽模式下的生成敌人
function A_EnemySpawnerCtrl.ShengChengNoEnd(enemytype,hp)
   -- local enemyObj=CSU.Object.Instantiate(A_CtrlMgr.abDTObj:PrefabAB(wave.type),EnemyPosition.transform.position,CSU.Quaternion.identity)
   -- local enemySliderCanvas=CSU.Object.Instantiate(A_CtrlMgr.abDTObj:PrefabAB("Hp"),EnemyPosition.transform.position,CSU.Quaternion.identity)
   
   --向对象池中获取物体
   local enemyObj=A_CtrlMgr.PrefabPool:GetEnemy(enemytype,EnemyPosition)
   local enemySliderCanvas=A_CtrlMgr.PrefabPool:GetEnemy("Hp",EnemyPosition)
   enemyObj.transform.position=EnemyPosition.transform.position

   --存入全局敌人列表
   table.insert(this.EnemyListSpawnered,enemyObj)
   --实例化敌人行为类, 传入对应血条UI，总血量，初始化当前血量,速度,敌人类型
   local EnemyObj=A_Enemy:New(enemyObj,enemySliderCanvas,hp,Level.enemyAttributes[enemytype].speed,Level.enemyAttributes[enemytype].getMoney)
   --告知当前关卡是无尽模式
   EnemyObj.IsNoEnd=true
   --存入行为类列表
   Index=Index+1
   --存入索引
   EnemyObj.IndexSelf=Index
   --存入敌人Update管理实例列表
   A_EnemyManager.EnemySelfList[Index]=EnemyObj
   --已经生成的敌人数量+1
   this.Enemycount=this.Enemycount+1
end



--敌人死亡，刷新全局敌人列表
function A_EnemySpawnerCtrl:UpdateALLEnemySpawnered(obj)
   for i=1,this.Enemycount do
      if(this.EnemyListSpawnered[i]==obj) then
         this.EnemyListSpawnered[i]=nil
         break
      end
   end
end



