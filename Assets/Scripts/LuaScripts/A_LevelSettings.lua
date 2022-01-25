--游戏关卡的数据管理

A_LevelSettings={}
local this=A_LevelSettings

function A_LevelSettings.GetInstance()
    return this
end

-------------------第一关-------------------
A_LevelSettings.Level_One={
	--初始金币数
	DefaultMoney=200,
	--敌人波次信息
	enemy={
		{count=4,type="A_Enemy1",speed=0.3},
		{count=6,type="A_Enemy2",speed=0.6},
		{count=9,type="A_Enemy1",speed=0.3}
	},
	--当前关卡可用炮塔的信息
	turret={
		"DefenseA","DefenseB","DefenseC"
	},
	--炮塔的属性：     价格       升级价格      伤害       子弹类型         子弹速度     攻击频率             视野范围            升级后属性...
	turretAttributes={
		["DefenseA"]={cost=70,UpgradeCost=50,damage=30,Bullet="DeABullet",speed=5,BulletattackRateTime=2,ViewDistance=5,UpgradeAttributes={damage=50,speed=7,BulletattackRateTime=1,ViewDistance=7}},
		["DefenseB"]={cost=80,UpgradeCost=100,damage=20,Bullet="DeBBullet",speed=7,BulletattackRateTime=0.4,ViewDistance=3,UpgradeAttributes={damage=30,speed=10,BulletattackRateTime=0.25,ViewDistance=5}},
		["DefenseC"]={cost=90,UpgradeCost=100,damage=5,Bullet="DeCBullet",speed=10,BulletattackRateTime=30,ViewDistance=4,UpgradeAttributes={damage=10,speed=12,BulletattackRateTime=20,ViewDistance=6}}
	},
	--不同类型敌人的属性: 血量
	enemyAttributes={
		["A_Enemy1"]={Hp=120,getMoney=40},
		["A_Enemy2"]={Hp=180,getMoney=60}
	},
	--同波次敌人生成间隔
	EnemyRateTime=1.5,
	--波次产生间隔
	WaveRateTime=5,

	--敌人生成位置
	enemySpawmerPosition="StartPosition_levelOne",
	--敌人总数
	AllenemyCounts=19
}
------------------第二关敌人数据--------------------
A_LevelSettings.Level_Two={
	--初始金币数
	DefaultMoney=500,
	--敌人波次信息
	enemy={
		{count=5,type="A_Enemy2",speed=0.66},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.6},
		{count=5,type="A_Enemy1",speed=0.3}
	},
	--当前关卡可用炮塔的信息
	turret={
		"DefenseA","DefenseB","DefenseC"
	},
	--炮塔的属性：     价格       升级价格      伤害       子弹类型         子弹速度     攻击频率             视野范围            升级后属性...
	turretAttributes={
		["DefenseA"]={cost=70,UpgradeCost=50,damage=30,Bullet="DeABullet",speed=5,BulletattackRateTime=2,ViewDistance=6,UpgradeAttributes={damage=40,speed=7,BulletattackRateTime=1,ViewDistance=8}},
		["DefenseB"]={cost=80,UpgradeCost=50,damage=10,Bullet="DeBBullet",speed=10,BulletattackRateTime=0.4,ViewDistance=3,UpgradeAttributes={damage=20,speed=12,BulletattackRateTime=0.25,ViewDistance=5}},
		["DefenseC"]={cost=90,UpgradeCost=50,damage=10,Bullet="DeCBullet",speed=10,BulletattackRateTime=30,ViewDistance=4,UpgradeAttributes={damage=15,speed=12,BulletattackRateTime=20,ViewDistance=6}}
	},
	--不同类型敌人的属性: 血量
	enemyAttributes={
		["A_Enemy1"]={Hp=300,getMoney=20},
		["A_Enemy2"]={Hp=200,getMoney=30}
	},
	--同波次敌人生成间隔
	EnemyRateTime=1.5,
	--波次产生间隔
	WaveRateTime=5,

	--敌人生成位置
	enemySpawmerPosition="StartPosition_levelTwo",
	--敌人总数
	AllenemyCounts=20
}

------------------第三关敌人数据--------------------

A_LevelSettings.Level_Three={
	--初始金币数
	DefaultMoney=500,
	--敌人波次信息
	enemy={
		{count=5,type="A_Enemy2",speed=0.66},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.6},
		{count=5,type="A_Enemy1",speed=0.3}
	},
	--当前关卡可用炮塔的信息
	turret={
		"DefenseA","DefenseB","DefenseC"
	},
	--炮塔的属性：     价格       升级价格      伤害       子弹类型         子弹速度     攻击频率             视野范围            升级后属性...
	turretAttributes={
		["DefenseA"]={cost=70,UpgradeCost=50,damage=30,Bullet="DeABullet",speed=5,BulletattackRateTime=2,ViewDistance=6,UpgradeAttributes={damage=40,speed=7,BulletattackRateTime=1,ViewDistance=8}},
		["DefenseB"]={cost=80,UpgradeCost=50,damage=10,Bullet="DeBBullet",speed=10,BulletattackRateTime=0.4,ViewDistance=3,UpgradeAttributes={damage=20,speed=12,BulletattackRateTime=0.25,ViewDistance=5}},
		["DefenseC"]={cost=90,UpgradeCost=50,damage=10,Bullet="DeCBullet",speed=10,BulletattackRateTime=30,ViewDistance=4,UpgradeAttributes={damage=15,speed=12,BulletattackRateTime=20,ViewDistance=6}}
	},
	--不同类型敌人的属性: 血量
	enemyAttributes={
		["A_Enemy1"]={Hp=300,getMoney=20},
		["A_Enemy2"]={Hp=200,getMoney=30}
	},
	--同波次敌人生成间隔
	EnemyRateTime=1.5,
	--波次产生间隔
	WaveRateTime=5,

	--敌人生成位置
	enemySpawmerPosition="StartPosition_levelThree",
	--敌人总数
	AllenemyCounts=20
}

----------------------------------狂欢模式--------------------------------------------
A_LevelSettings.Level_Crazy={
	--初始金币数
	DefaultMoney=800,
	--敌人波次信息
	enemy={
		{count=5,type="A_Enemy2",speed=0.66},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.6},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.66},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.6},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.66},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.6},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.66},
		{count=5,type="A_Enemy1",speed=0.3},
		{count=5,type="A_Enemy2",speed=0.6},
		{count=5,type="A_Enemy1",speed=0.3}
	},
	--当前关卡可用炮塔的信息
	turret={
		"DefenseA","DefenseB","DefenseC"
	},
	--炮塔的属性：     价格       升级价格      伤害       子弹类型         子弹速度     攻击频率             视野范围            升级后属性...
	turretAttributes={
		["DefenseA"]={cost=70,UpgradeCost=50,damage=50,Bullet="DeABullet",speed=8,BulletattackRateTime=2,ViewDistance=8,UpgradeAttributes={damage=70,speed=10,BulletattackRateTime=1,ViewDistance=10}},
		["DefenseB"]={cost=80,UpgradeCost=50,damage=20,Bullet="DeBBullet",speed=13,BulletattackRateTime=0.4,ViewDistance=5,UpgradeAttributes={damage=35,speed=15,BulletattackRateTime=0.25,ViewDistance=7}},
		["DefenseC"]={cost=90,UpgradeCost=50,damage=20,Bullet="DeCBullet",speed=13,BulletattackRateTime=30,ViewDistance=6,UpgradeAttributes={damage=35,speed=15,BulletattackRateTime=20,ViewDistance=8}}
	},
	--不同类型敌人的属性: 血量
	enemyAttributes={
		["A_Enemy1"]={Hp=550,getMoney=40},
		["A_Enemy2"]={Hp=800,getMoney=60}
	},
	--同波次敌人生成间隔
	EnemyRateTime=1.5,
	--波次产生间隔
	WaveRateTime=5,

	--敌人生成位置
	enemySpawmerPosition="StartPosition_levelThree",
	--敌人总数
	AllenemyCounts=80
}


------------------无尽模式------------------------
A_LevelSettings.Level_NoEnd={
	--初始金币数
	DefaultMoney=500,
	--当前关卡可用炮塔的信息
	turret={
		"DefenseA","DefenseB","DefenseC"
	},
	--炮塔的属性：     价格       升级价格      伤害       子弹类型         子弹速度     攻击频率             视野范围            升级后属性...
	turretAttributes={
		["DefenseA"]={cost=70,UpgradeCost=50,damage=30,Bullet="DeABullet",speed=5,BulletattackRateTime=2,ViewDistance=6,UpgradeAttributes={damage=40,speed=7,BulletattackRateTime=1,ViewDistance=8}},
		["DefenseB"]={cost=80,UpgradeCost=50,damage=10,Bullet="DeBBullet",speed=10,BulletattackRateTime=0.4,ViewDistance=3,UpgradeAttributes={damage=20,speed=12,BulletattackRateTime=0.25,ViewDistance=5}},
		["DefenseC"]={cost=90,UpgradeCost=50,damage=10,Bullet="DeCBullet",speed=10,BulletattackRateTime=30,ViewDistance=4,UpgradeAttributes={damage=15,speed=12,BulletattackRateTime=20,ViewDistance=6}}
	},
	--不同类型敌人的属性: 血量
	enemyAttributes={
		["A_Enemy1"]={Hp=100,getMoney=20,speed=0.3},
		["A_Enemy2"]={Hp=120,getMoney=30,speed=0.66}
	},
	--同波次敌人生成间隔
	EnemyRateTime=2,
	--敌人生成位置
	enemySpawmerPosition="StartPosition_leveNoEnd"
}