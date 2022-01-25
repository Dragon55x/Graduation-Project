---
--- 失败窗口  UI窗体视图层脚本
---

DefeatUIForm = {}
local this = DefeatUIForm


local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local Lua_Helper=CS.LuaFramework.LuaHelper 
local luaHelper=Lua_Helper.GetInstance()

local Load_Manager=CS.UIFW.LoadManager.GetInstance()

local transform
local gameobject

--得到实例
function DefeatUIForm.GetInstance()
    return this
 end

function DefeatUIForm.Awake(obj)
    
    gameobject=obj
    transform=obj.transform
end

function DefeatUIForm.Start(obj)
    this.InitView()
end

function DefeatUIForm.InitView()
    --重新开始
    this.PlayNormalBtn=transform:Find("Image/Restart"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalBtn.onClick:AddListener(this.ProcessRestart)

    --返回游戏大厅
    this.PlayNormalBtn=transform:Find("Image/Back"):GetComponent("UnityEngine.UI.Button") 
    this.PlayNormalBtn.onClick:AddListener(this.ProcessBackHallBtn)

end

function DefeatUIForm.ProcessRestart()  --重新开始
      
    local s =CS.UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    Load_Manager:Load(s)
    uiManager:CloseUIForms("DefeatUIForm")
    --找到当前场景游戏开始节点
    --？？？
end


function DefeatUIForm.ProcessBackHallBtn()
  
    CS.UnityEngine.SceneManagement.SceneManager.LoadScene("GameHall");
   
end

