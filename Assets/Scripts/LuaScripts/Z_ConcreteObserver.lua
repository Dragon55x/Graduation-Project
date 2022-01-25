--require  ("Z_Observer")

-- 继承
Z_ConcreteObserver = Z_Observer:new()
function Z_ConcreteObserver:UpgradeCoinUI()
    --找到UI上的金币框并更新
	CSU.GameObject.Find("Canvas(Clone)").transform:Find("Fixed/GameInfoUIForm(Clone)/Coins/Text"):GetComponent("UnityEngine.UI.Text").text=A_CtrlMgr.Money.number
end