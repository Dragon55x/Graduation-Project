---
--- 聊天窗口  UI窗体视图层脚本
---

CommuUIForm = {}
local this = CommuUIForm


local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local Lua_Helper=CS.LuaFramework.LuaHelper 
local luaHelper=Lua_Helper.GetInstance()

local transform
local gameobject

--得到实例
function CommuUIForm.GetInstance()
    return this
 end

function CommuUIForm.Awake(obj)
    
    gameobject=obj
    transform=obj.transform
end

function CommuUIForm.Start(obj)
    this.InitView()
end

function CommuUIForm.Update(obj)
    transform:Find("Panel/Show/Text"):GetComponent("UnityEngine.UI.Text").text =CS.Communication.CommuManager.showContent
end
function CommuUIForm.InitView()
    --查找UI中按钮
    this.SendBtn=transform:Find("Panel/Send")--返回transform
    this.SendBtn=this.SendBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.SendBtn.onClick:AddListener(this.ProcessSendBtn)
    
    this.CloseBtn=transform:Find("Panel/Close")--返回transform
    this.CloseBtn=this.CloseBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.CloseBtn.onClick:AddListener(this.ProcessClose)
end

function CommuUIForm.ProcessSendBtn()

    this.txtInput=transform:Find("Panel/InputField/Text"):GetComponent("UnityEngine.UI.Text")
    local content = this.txtInput.text
    --cs
    CS.Communication.CommuManager.GetInstance():SendMes(content)
    
end


function CommuUIForm.ProcessClose()
   
    
    uiManager:CloseUIForms("CommuUIForm")
end