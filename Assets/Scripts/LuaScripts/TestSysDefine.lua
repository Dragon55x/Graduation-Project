-----------------游戏内的常量定义--------------------
--游戏中需要的控制层脚本
CtrlName={
    A_EnemySpawnerCtrl="A_EnemySpawnerCtrl",
    A_BuildManagerCtrl="A_BuildManagerCtrl",
    A_MapCubeCtrl="A_MapCubeCtrl",
    A_TurretShootCtrl="A_TurretShootCtrl",
    A_BulletCtrl="A_BulletCtrl"
}
--视图层脚本
-- TViewNames={
--     "DefenseListUIForm"
-- }
A_CtrlNames={
    --观察者模式控制脚本
    "Z_Observer",--观察者模式基类
    "Z_ConcreteObserver",--观察者
    "Z_ObservationPost",--被观察者
    
    --对象池脚本
    "PrefabObjectPool",

    --游戏逻辑控制脚本
    "A_BaseList",--封装List类
    "A_LevelSettings",--关卡数据
    "A_SettlementCtrl",--游戏结算
    "A_EnemySpawnerCtrl",--敌人生成管理   
    "A_BuildManagerCtrl",--炮塔建造管理
}
A_ViewNames={
    "A_TurretManager",--炮塔生命周期
    "A_BulletManager",--子弹生命周期
    "A_EnemyManager",--敌人生命周期

    "A_Turret",--炮塔行为类
    "A_BulletAB",--子弹行为类
    "A_Enemy",--敌人行为类
    
    "DefeatUIForm",
}

--引入Unity内置的类型
WWW=CS.UnityEngine.WWW
GameObject=CS.UnityEngine.GameObject
CSU=CS.UnityEngine
--游戏场景CS工具类
GameTool=CS.GameTools.A_GameHelper