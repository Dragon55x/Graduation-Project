---
--- 登录窗口  UI窗体视图层脚本
---

LogonUIForm = {}
local this = LogonUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

-- 标题【welcome】
local logonTitle="《赛博朋克2188》"

local transform
local gameobject
--说明:
--输入参数： obj 表示UI窗体对象。
function LogonUIForm.Awake(obj)
   gameobject=obj
   transform=obj.transform
end

function LogonUIForm.Start(obj)
    --查找与设置通知的标题 
    this.txtTitle=transform:Find("BG/TxtTitle"):GetComponent("UnityEngine.UI.Text")
    this.txtTitle.text=logonTitle

    this.InitView()
end
function LogonUIForm.InitView()
    
    --查找UI中登录按钮
    this.OKBtn=transform:Find("BG/Btn_OK")
    this.OKBtn=this.OKBtn:GetComponent("UnityEngine.UI.Button") 
    this.OKBtn.onClick:AddListener(this.ProcessOKBtn)

    --查找UI中注册按钮
    this.ResBtn=transform:Find("BG/Btn_Res")
    this.ResBtn=this.ResBtn:GetComponent("UnityEngine.UI.Button") 
    this.ResBtn.onClick:AddListener(this.ProcessResBtn)
end

function LogonUIForm.ProcessOKBtn()
  
    --用户名
    this.txtInp_ID=transform:Find("BG/Inp_ID/Text"):GetComponent("UnityEngine.UI.Text")
    --密码
    this.Inp_PW=transform:Find("BG/Inp_PW/Text"):GetComponent("UnityEngine.UI.Text")

    uiManager:ShowUIForms("StoryUIForm")
    --print(this.txtInp_ID.text)
    --判断打开窗体
    
    -- if CS.LoginRes.Login.LogIn(this.txtInp_ID.text,this.Inp_PW.text) then
    --     uiManager:ShowUIForms("StoryUIForm")
    -- else 
      
    --     uiManager:ShowUIForms("LoginFailUIForm")  
    -- end
end


function LogonUIForm.ProcessResBtn()
    uiManager:ShowUIForms("ResUIForm")
end