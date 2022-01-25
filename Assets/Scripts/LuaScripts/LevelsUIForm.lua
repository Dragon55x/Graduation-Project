---
--- 选择关卡窗口  UI窗体视图层脚本
---
require("TestSysDefine")


LevelsUIForm = {}
local this = LevelsUIForm


local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local Load_Manager=CS.UIFW.LoadManager.GetInstance()

local Lua_Helper=CS.LuaFramework.LuaHelper 
local luaHelper=Lua_Helper.GetInstance()

local transform
local gameobject

--得到实例
function LevelsUIForm.GetInstance()
    return this
 end

function LevelsUIForm.Awake(obj)
    print("------- LevelsUIForm.Awake  -----------");
    gameobject=obj
    transform=obj.transform
end

function LevelsUIForm.Start(obj)
    this.InitView()
end

function LevelsUIForm.InitView()
    --第一关
    this.PlayNormalBtn=transform:Find("Panel/Show/Levels/Level_One"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalBtn.onClick:AddListener(this.ProcessLevel_One)
    --第二关
    this.PlayNormalTwoBtn=transform:Find("Panel/Show/Levels/Level_Two"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalTwoBtn.onClick:AddListener(this.ProcessLevel_Two)
    --第三关
    this.PlayNormalThreeBtn=transform:Find("Panel/Show/Levels/Level_Three"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalThreeBtn.onClick:AddListener(this.ProcessLevel_Three)
    --返回游戏大厅
    this.PlayNormalBackBtn=transform:Find("Panel/Close"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalBackBtn.onClick:AddListener(this.ProcessBackHallBtn)

end

function LevelsUIForm.ProcessLevel_One()
   
    print("执行到 ProcessLevel_One")  --开始关卡1游戏
    --卸载所有lua脚本
    --this.Unload()
    --解场景包
    uiManager:ShowUIForms("GameInfoUIForm")
    uiManager:ShowUIForms("DefenseListUIForm")

    Load_Manager:Load("Level_One")
    
    
end

function LevelsUIForm.ProcessLevel_Two()
   
    print("执行到 ProcessLevel_Two")  --开始关卡2游戏
    --卸载所有lua脚本
    --this.Unload()
    --解场景包
    uiManager:ShowUIForms("GameInfoUIForm")
    uiManager:ShowUIForms("DefenseListUIForm")

    Load_Manager:Load("Level_Two")
    
end

function LevelsUIForm.ProcessLevel_Three()
   
    print("执行到 ProcessLevel_Three")  --开始关卡3游戏
    --卸载所有lua脚本
    --this.Unload()
    --解场景包
    uiManager:ShowUIForms("GameInfoUIForm")
    uiManager:ShowUIForms("DefenseListUIForm")

    Load_Manager:Load("Level_Three")
    
end



function LevelsUIForm.ProcessBackHallBtn()
    print("执行到 ProcessBackHallBtn")  
    uiManager:ShowUIForms("MainCityUIForm")
    uiManager:ShowUIForms("HeroInfoUIForm")
end

function LevelsUIForm.Unload()
    for i=1, #A_ViewNames do
        package.loaded[A_ViewNames[i]] = nil
    end
    print("卸载视图层脚本成功")

    for i=1, #A_CtrlNames do
        package.loaded[A_CtrlNames[i]] = nil
    end
    package.loaded["A_StartGame"]=nil
    package.loaded["A_CtrlMgr"]=nil
    print("卸载控制层脚本成功")
end
