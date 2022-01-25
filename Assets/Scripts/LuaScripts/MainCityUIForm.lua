---
--- 主视图窗口  UI窗体视图层脚本
---

MainCityUIForm = {}
local this = MainCityUIForm


local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local Lua_Helper=CS.LuaFramework.LuaHelper 
local luaHelper=Lua_Helper.GetInstance()

local Load_Manager=CS.UIFW.LoadManager.GetInstance()


local transform
local gameobject

--得到实例
function MainCityUIForm.GetInstance()
    return this
 end

function MainCityUIForm.Awake(obj)
    
    gameobject=obj
    transform=obj.transform
end

function MainCityUIForm.Start(obj)
    this.InitView()
end

function MainCityUIForm.InitView()
    --查找UI中按钮
    this.PlayNormalBtn=transform:Find("PlayNormal")--返回transform
    this.PlayNormalBtn=this.PlayNormalBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.PlayNormalBtn.onClick:AddListener(this.ProcessPlayNormal)

    this.MarketBtn=transform:Find("BtnMarket")--返回transform
    this.MarketBtn=this.MarketBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.MarketBtn.onClick:AddListener(this.ProcessMarket)

    this.EmallBtn=transform:Find("BtnEmall")--返回transform
    this.EmallBtn=this.EmallBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.EmallBtn.onClick:AddListener(this.ProcessEmallBtn)

    this.CommuBtn=transform:Find("Btncommunication")--返回transform
    this.CommuBtn=this.CommuBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.CommuBtn.onClick:AddListener(this.ProcessCommuBtn)

    this.PlayCrazyBtn=transform:Find("PlayCrazy")--返回transform
    this.PlayCrazyBtn=this.PlayCrazyBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.PlayCrazyBtn.onClick:AddListener(this.ProcessPlayCrazy)

    this.PlayCopyBtn=transform:Find("PlayCopy")--返回transform
    this.PlayCopyBtn=this.PlayCopyBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.PlayCopyBtn.onClick:AddListener(this.ProcessPlayCopy)
end

function MainCityUIForm.ProcessPlayNormal()
    uiManager:ShowUIForms("LevelsUIForm")
    uiManager:CloseUIForms("HeroInfoUIForm")
end

function MainCityUIForm.ProcessMarket()
   
    
    uiManager:ShowUIForms("MarketUIFrom")
end

function MainCityUIForm.ProcessEmallBtn()
   
    
    uiManager:ShowUIForms("NotificationUIForm")
end

function MainCityUIForm.ProcessCommuBtn()
   
    
    uiManager:ShowUIForms("CommuUIForm")
end

function MainCityUIForm.ProcessPlayCrazy()
   
    uiManager:ShowUIForms("GameInfoUIForm")
    uiManager:ShowUIForms("DefenseListUIForm")
    Load_Manager:Load("Level_Crazy")
end

function MainCityUIForm.ProcessPlayCopy()
   
    uiManager:ShowUIForms("GameInfoUIForm")
    uiManager:ShowUIForms("DefenseListUIForm")
    Load_Manager:Load("Level_NoEnd")
end