---
--- 防御塔窗口  UI窗体视图层脚本
---

MarketUIFrom = {}
local this = MarketUIFrom


local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()


local transform
local gameobject

local baseuiform
--得到实例
function MarketUIFrom.GetInstance()
    return this
end

function MarketUIFrom.Awake(obj)
    
    gameobject=obj
    transform=obj.transform
    baseuiform=gameobject:GetComponent("BaseUIForm")
end

function MarketUIFrom.Start(obj)
    this.InitView()
end

function MarketUIFrom.InitView()
    --关闭
    this.CloseBtn=transform:Find("Btn_Close"):GetComponent("UnityEngine.UI.Button") 
    this.CloseBtn.onClick:AddListener(this.ProcessBtn_Close)
    --防御塔A
    this.DefenseA=transform:Find("DefenseA"):GetComponent("UnityEngine.UI.Button") 
    this.DefenseA.onClick:AddListener(this.ProcessBtn_DefenseA)
    --防御塔B
    this.DefenseB=transform:Find("DefenseB"):GetComponent("UnityEngine.UI.Button") 
    this.DefenseB.onClick:AddListener(this.ProcessBtn_DefenseB)
    --防御塔C
    this.DefenseC=transform:Find("DefenseC"):GetComponent("UnityEngine.UI.Button")
    this.DefenseC.onClick:AddListener(this.ProcessBtn_DefenseC)
end

function MarketUIFrom.ProcessBtn_Close()
    
    uiManager:CloseUIForms("MarketUIFrom")
end

--给防御塔列表按钮绑定点击事件
function MarketUIFrom.ProcessBtn_DefenseA()
   
    uiManager:ShowUIForms("PropDetailUIForm")
    local strArray ="详细介绍：\n\n<b>B11型火箭弹发射塔</b>\r\n\n　　射程5（升级后7），攻击速度1，伤害30（升级后50），建造花费70（升级花费50） \r\n\n　　职业选手推荐指数：5 \r\n\n　　新型的耐腐蚀火箭弹发射塔，发射X2火箭弹，可以对机器人造成不可逆转的伤害，防机器人必备。" 
    baseuiform:SendMessage("Detail",strArray)
end

function MarketUIFrom.ProcessBtn_DefenseB()
    uiManager:ShowUIForms("PropDetailUIForm")
    local strArray ="详细介绍：\n\n<b>M56机关枪</b>\r\n\n　　射程3（升级后5），攻击速度0.5，伤害10（升级后30），建造花费80（升级花费100） \r\n\n　　职业选手推荐指数：4 \r\n\n　　发射AE4高速电磁子弹，机器人感觉不到疼痛，但是一定能感觉到漏电，甚至是短路,但是噪音有点大。" 
    baseuiform:SendMessage("Detail", strArray)
end

function MarketUIFrom.ProcessBtn_DefenseC()
    uiManager:ShowUIForms("PropDetailUIForm")
    local strArray ="详细介绍：\n\n<b>GHC激光炮</b>\r\n\n　　射程4（升级后6），攻击速度30，伤害5（升级后10），建造花费90（升级花费100） \r\n\n　　职业选手推荐指数：8 \r\n\n　　5000℃的高温，就算是金属也能瞬间烧出来一个大窟窿，对付机器人绝对是神器，你问我它有什么缺点，除了贵，没有！" 
    baseuiform:SendMessage("Detail", strArray)
end

