---
--- 头像金币窗口  UI窗体视图层脚本
---
require("TestSysDefine")
GameInfoUIForm = {}
local this = GameInfoUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local transform
local gameobject

--得到实例
function HeroInfoUIForm.GetInstance()
   return this
end

function GameInfoUIForm.Awake(obj)
  
   gameobject=obj
   transform=obj.transform
end

function GameInfoUIForm.Start(obj)
   coinsNumber=transform:Find("Coins/Text"):GetComponent("UnityEngine.UI.Text")
   
   this.InitView()
end

function GameInfoUIForm.InitView()
   --查找UI中按钮
   this.BackBtn=transform:Find("BackGameHall")
   this.BackBtn=this.BackBtn:GetComponent("UnityEngine.UI.Button") 
   this.BackBtn.onClick:AddListener(this.ProcessBackHallBtn)

end

function GameInfoUIForm.ProcessBackHallBtn()
  
  


   --卸载所有lua脚本
   for i=1, #A_ViewNames do
      package.loaded[A_ViewNames[i]] = nil
   end
 

   for i=1, #A_CtrlNames do
      package.loaded[A_CtrlNames[i]] = nil
   end
   package.loaded["A_StartGame"]=nil
   package.loaded["A_CtrlMgr"]=nil
 

   --打开窗体
   uiManager:ShowUIForms("MainCityUIForm")
   uiManager:ShowUIForms("HeroInfoUIForm")
   CS.UnityEngine.SceneManagement.SceneManager.LoadScene("GameHall");
end