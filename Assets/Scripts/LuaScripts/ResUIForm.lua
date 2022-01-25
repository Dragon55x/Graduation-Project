---
--- 注册窗口  UI窗体视图层脚本
---

ResUIForm = {}
local this = ResUIForm

TowerForm = {}

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local transform
local gameobject
--说明:
--输入参数： obj 表示UI窗体对象。
function ResUIForm.Awake(obj)
   gameobject=obj
   transform=obj.transform
end

function ResUIForm.Start(obj)
   this.InitView()
end

function ResUIForm.InitView()   
   --查找UI中注册按钮
   this.ResBtn=transform:Find("Image/ResButton"):GetComponent("UnityEngine.UI.Button") 
   this.ResBtn.onClick:AddListener(this.ProcessResBtn)

   this.CloseBtnBtn=transform:Find("Image/CloseBtn"):GetComponent("UnityEngine.UI.Button") 
   this.CloseBtnBtn.onClick:AddListener(this.ProcessCloseBtn)
end

function ResUIForm.ProcessResBtn()
   print("执行到 ProcessResBtn")
    --昵称
    this.InputName=transform:Find("Image/InputName/Text"):GetComponent("UnityEngine.UI.Text")
    --账号
    this.InputID=transform:Find("Image/InputID/Text"):GetComponent("UnityEngine.UI.Text")
    --密码
    this.InputPaw=transform:Find("Image/InputPaw/Text"):GetComponent("UnityEngine.UI.Text")
    
    
    --注册  存储
    if CS.LoginRes.Savegame.SaveGame(this.InputID.text,this.InputName.text,this.InputPaw.text,0,TowerForm) then
      print("注册成功lua")
    else 
      print("注册失败lua")
    end
   uiManager:CloseUIForms("ResUIForm")
end

function ResUIForm.ProcessCloseBtn()
   uiManager:CloseUIForms("ResUIForm")
end