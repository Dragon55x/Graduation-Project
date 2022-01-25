---
--- 主视图上部 UI窗体视图层脚本
---
---
HeroInfoUIForm = {}
local this = HeroInfoUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local transform
local gameobject

--得到实例
function HeroInfoUIForm.GetInstance()
   return this
end

--说明:
--输入参数： obj 表示UI窗体对象。
function HeroInfoUIForm.Awake(obj)
 
    gameobject=obj
    transform=obj.transform
end

function HeroInfoUIForm.Start(obj)
    coinsNumber=transform:Find("Coins/Text"):GetComponent("UnityEngine.UI.Text")
   
    this.InitView()
end

function HeroInfoUIForm.InitView()
    --查找UI中按钮
    this.BackBtn=transform:Find("BtnItem1")--返回transform
    this.BackBtn=this.BackBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.BackBtn.onClick:AddListener(this.ProcessBackBtn)

end

function HeroInfoUIForm.ProcessBackBtn()

    --打开窗体
    uiManager:ShowUIForms("LogonUIForm")
    
 end
