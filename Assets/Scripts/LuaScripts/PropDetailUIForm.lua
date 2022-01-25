---
--- 详情窗口  UI窗体视图层脚本
---

PropDetailUIForm = {}
local this = PropDetailUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local transform
local gameobject

--得到实例
function PropDetailUIForm.GetInstance()
    return this
end

function PropDetailUIForm.Awake(obj)
   
    gameobject=obj
    transform=obj.transform
end

function PropDetailUIForm.Start(obj)
    this.InitView()
end

function PropDetailUIForm.InitView()
    --查找UI中按钮
    this.CloseBtn=transform:Find("BtnClose")--返回transform
    this.CloseBtn=this.CloseBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.CloseBtn.onClick:AddListener(this.ProcessBtn_Close)
end

function PropDetailUIForm.ProcessBtn_Close()
    uiManager:CloseUIForms("PropDetailUIForm")
end