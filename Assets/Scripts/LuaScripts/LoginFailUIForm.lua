---
--- 登录失败窗口  UI窗体视图层脚本
---

LoginFailUIForm = {}
local this = LoginFailUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local transform
local gameobject
--说明:
--输入参数： obj 表示UI窗体对象。
function LoginFailUIForm.Awake(obj)
   gameobject=obj
   transform=obj.transform
end

function LoginFailUIForm.Start(obj)
   this.InitView()
end

function LoginFailUIForm.InitView()
    
   --查找UI中登录按钮
   this.BackBtn=transform:Find("Back")
   this.BackBtn=this.BackBtn:GetComponent("UnityEngine.UI.Button") 
   this.BackBtn.onClick:AddListener(this.ProcessBackBtn)
end

function LoginFailUIForm.ProcessBackBtn()
   
   uiManager:CloseUIForms("LoginFailUIForm")
end
