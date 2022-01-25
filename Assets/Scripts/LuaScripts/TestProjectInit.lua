
TestProjectInit={}
local this=TestProjectInit

-------------UI控制-----------------
function TestProjectInit.Game_Init()
    --导入引入项目中所有的视图层脚本
    this.ImportAllCtrls()

    this.ImportAllViews()
end





--导入游戏种所有的控制层脚本
function TestProjectInit.ImportAllCtrls()
    for i=1, #A_CtrlNames do
        --package.preload[A_CtrlNames[i]] = nil
        package.loaded[A_CtrlNames[i]] = nil
        require(A_CtrlNames[i])
    end
    require("A_CtrlMgr")
    --print("导入控制层脚本成功")
end
--导入游戏中所有的视图层脚本
function TestProjectInit.ImportAllViews()
    --UI框架视图层
    -- for i = 1, #TViewNames do
    --     --package.preload[TViewNames[i]] = nil
    --     package.loaded[TViewNames[i]] = nil
    --     require(TViewNames[i])
    -- end
    --游戏场景视图层
    for i=1, #A_ViewNames do
        --package.preload[A_ViewNames[i]] = nil
        package.loaded[A_ViewNames[i]] = nil
        require(A_ViewNames[i])
    end
    --print("导入视图层脚本成功")
end

















