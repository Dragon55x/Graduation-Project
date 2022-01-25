--控制层管理器


A_CtrlMgr={
    abDTObj=CS.PFW.DefenseManager.GetInstance(), 
	Money=nil,
	PrefabPool=nil
}
local this=A_CtrlMgr


function A_CtrlMgr.Init()
 
	A_EnemyManager.EnemySelfList={}
	A_TurretManager.DefenseList={}
	A_BulletManager.Bulletlist={}


	--实例化对象池
	this.PrefabPool=PrefabObjectPool:New()

    --------------------------加载建造管理脚本-------------------------------------------
	--拿到炮塔建造管理空物体
	local buildManager=CSU.GameObject.Find("A_BuildManagerCtrl")
	CS.LuaFramework.LuaHelper.GetInstance():AddBaseLuaUIForm(buildManager)
	-- local BuildObj=A_BuildManagerCtrl.GetInstance() --得到建造管理类的实例
    -- BuildObj.StartProcess()
	--------------------------加载敌人生成管理脚本----------------------------------------
	--需要根据关卡不同执行不同的敌人生成函数
	--拿到敌人生成管理空物体
	local enemyspawner=CSU.GameObject.Find("A_EnemySpawnerCtrl")
	CS.LuaFramework.LuaHelper.GetInstance():AddBaseLuaUIForm(enemyspawner)
	-- local EneObj=A_EnemySpawnerCtrl.GetInstance() --得到敌人生成管理类的实例
	-- EneObj.StartProcess(LevelSettings.levelOne_enemy)

	local turretManager=CSU.GameObject.Find("GameObjectManager").transform:Find("A_TurretManager")
	CS.LuaFramework.LuaHelper.GetInstance():AddBaseLuaUIForm(turretManager)
	local bulletManager=CSU.GameObject.Find("GameObjectManager").transform:Find("A_BulletManager")
	CS.LuaFramework.LuaHelper.GetInstance():AddBaseLuaUIForm(bulletManager)
	local enemyManager=CSU.GameObject.Find("GameObjectManager").transform:Find("A_EnemyManager")
	CS.LuaFramework.LuaHelper.GetInstance():AddBaseLuaUIForm(enemyManager)

    --建立金币观察者模式
	this.ObserverOpen()

end


--声明观察者
ObserverOne={}

function A_CtrlMgr.ObserverOpen()
	--创建对金币的观察者模式监听
	--注册被观察者，声明金币
	this.Money=Z_ObservationPost:new()
	this.Money.number=nil
	--注册观察者
	ObserverOne=Z_ConcreteObserver:new()
	--添加观察者
	this.Money:add(ObserverOne)
	--print("观察者模式添加成功")
end


	
