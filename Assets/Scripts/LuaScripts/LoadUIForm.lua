---
--- 登录窗口  UI窗体视图层脚本
---

LoadUIForm = {}
local this = LoadUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

-- 百分比
local percent = "0%"
local loadSlider
local transform
local gameobject

function LoadUIForm.Awake(obj)
   gameobject=obj
   transform=obj.transform
   
end

function LoadUIForm.Start(obj)
    --查找与设置通知的标题 
    this.txtTitle=transform:Find("Image/Slider/percent"):GetComponent("UnityEngine.UI.Text")
    this.txtTitle.text=percent

    this.loadSlider=transform:Find("Image/Slider"):GetComponent("UnityEngine.UI.Slider") 
end

function LoadUIForm.Update(obj)
    --查找与设置通知的标题 
    this.txtTitle.text=percent

    --查找滑杆

end

function LoadUIForm.StartLoading(str)
    local i ;
    CSU.AsyncOperation = CSU.SceneManagement.SceneManager.LoadSceneAsync(str)
    acOp.allowSceneActivation = false;
    while i<100 do
        this.loadSlider.value = i / 100;
    end
end

