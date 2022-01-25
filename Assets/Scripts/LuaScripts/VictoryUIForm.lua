---
--- 胜利窗口  UI窗体视图层脚本
---

VictoryUIForm = {}
local this = VictoryUIForm


local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local Lua_Helper=CS.LuaFramework.LuaHelper 
local luaHelper=Lua_Helper.GetInstance()

local Load_Manager=CS.UIFW.LoadManager.GetInstance()

local transform
local gameobject

--得到实例
function VictoryUIForm.GetInstance()
    return this
 end

function VictoryUIForm.Awake(obj)
    print("------- VictoryUIForm.Awake  -----------");
    gameobject=obj
    transform=obj.transform
end

function VictoryUIForm.Start(obj)
    this.InitView()
end

function VictoryUIForm.InitView()
    --选择关卡
    this.PlayNormalBtn=transform:Find("Image/SelectLevel"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalBtn.onClick:AddListener(this.ProcessSelectLevel)


    --返回游戏大厅
    this.BackHallBtn=transform:Find("Image/Back"):GetComponent("UnityEngine.UI.Button") 
    this.BackHallBtn.onClick:AddListener(this.ProcessBackHallBtn)

end

function VictoryUIForm.ProcessSelectLevel()  --再来一局
    print("执行到 ProcessSelectLevel")  
    local s =CS.UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    Load_Manager:Load(s)
    uiManager:CloseUIForms("VictoryUIForm")
end


function VictoryUIForm.ProcessBackHallBtn()
    
    print("执行到 ProcessBackHallBtn")  
    CS.UnityEngine.SceneManagement.SceneManager.LoadScene("GameHall");
end

