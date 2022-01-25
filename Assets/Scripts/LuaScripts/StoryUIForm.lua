---
--- 背景故事 UI窗体视图层脚本
---
---
StoryUIForm = {}

local this = StoryUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

local transform
local gameobject


-- 故事背景内容
local Content="\n<b>X博士：</b>\r\n\n　　故事发生在人工智能超过奇点的一世纪后。\r\n　　由于人类对机器人的不信任和机器人对人的敌意，大家都知道有一场战争迟早要来到。这一场不可避免的悲剧，最终还是在2188年11月19日的凌晨爆发了。\r\n\n　　我们人类的间谍发现了机器人计划毁灭人类的巨大阴谋，而间谍在传回消息后无奈暴露，机器人由此向人类挑起了剧烈的全面战争！你作为一名高阶机械师，我们的家园需要你的守护！\r\n\n　　　　　　　　　　　　　　朋克世纪 2188年12月11日"


--得到实例
function StoryUIForm.GetInstance()
   return this
end

--说明:
--输入参数： obj 表示UI窗体对象。
function StoryUIForm.Awake(obj)
    print("------- StoryUIForm.Awake  -----------");
    gameobject=obj
    transform=obj.transform
end

function StoryUIForm.Start(obj)
   --查找与设置通知的标题 
    this.txtContent=transform:Find("ScrollView/Content/Text"):GetComponent("UnityEngine.UI.Text")
    this.txtContent.text=Content
    this.InitView()
end

function StoryUIForm.InitView()
    print("------------------------------------------------------------------");
    --查找UI中按钮
    this.ContinueBtn=transform:Find("BtnConfirm")--返回transform
    this.ContinueBtn=this.ContinueBtn:GetComponent("UnityEngine.UI.Button") --返回Button类型
    this.ContinueBtn.onClick:AddListener(this.ProcessContinueBtn)

end

function StoryUIForm.ProcessContinueBtn()
    --加载AB包
    print("执行到 ProcessContinueBtn")
    --打开窗体
    uiManager:ShowUIForms("MainCityUIForm")
    uiManager:ShowUIForms("HeroInfoUIForm")
 end
