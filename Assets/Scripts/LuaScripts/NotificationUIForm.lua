
--- 公告栏  UI窗体视图层脚本


--定义字段
NotificationUIForm={}
local this=NotificationUIForm

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

--公告标题
local strNotiTitle="<color='#ff0000ff'>公告</color>"
--公告内容
local strNotiContent="<b>亲爱的玩家们：</b>\r\n\n　　由于服务器异常，“更多模式”出现了一些小问题，目前技术小哥正在紧急修复中，并将邮件模块暂时关闭。\r\n\n　　各位小伙伴们不用担心，问题修复后，会第一时间通知大家，给大家带来的不便，还请原谅！\r\n\n　　感谢大家多年以来对本游戏的关心与爱护\r\n\n　　　　　　　　　　　　　　　　X-AOD 3021年8月25日"
local transform
local gameobject
--说明:
--输入参数： obj 表示UI窗体对象。
function NotificationUIForm.Awake(obj)
  
   gameobject=obj
   transform=obj.transform
   
end

function NotificationUIForm.Start(obj)
    
    --查找与设置通知的标题 
    this.txtTitle=transform:Find("Txt_Title"):GetComponent("UnityEngine.UI.Text")
    this.txtTitle.text=strNotiTitle
    --查找与设置通知的内容
    this.txtContent=transform:Find("Scroll View/Viewport/Content/Text"):GetComponent("UnityEngine.UI.Text")
    this.txtContent.text=strNotiContent
    --查找UI中按钮
    this.ConfirmBtn=transform:Find("BtnConfirm"):GetComponent("UnityEngine.UI.Button")
    this.ConfirmBtn.onClick:AddListener(this.ProcessConfirm)
end

function NotificationUIForm.ProcessConfirm()
    uiManager:CloseUIForms("NotificationUIForm")
end


