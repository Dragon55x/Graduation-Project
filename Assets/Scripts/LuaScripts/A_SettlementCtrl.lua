--游戏结算脚本

A_SettlementCtrl={}
this=A_SettlementCtrl

local IsOpenWin=false
local IsOpenFail=false

local UI_Manager=CS.UIFW.UIManager
local uiManager=UI_Manager.GetInstance()

function A_SettlementCtrl.GetInstance()
 	return this
end



--赢得战斗
function A_SettlementCtrl:Win()
  this.Unload()
  if IsOpenWin==false then
    uiManager:ShowUIForms("VictoryUIForm")
    IsOpenWin=true
  end
end
--战败
function A_SettlementCtrl:Failed()
  this.Unload()
  if IsOpenFail==false then
    uiManager:ShowUIForms("DefeatUIForm")
    IsOpenFail=true
  end

end 
--重玩
function A_SettlementCtrl:Retry()

end
--返回菜单
function A_SettlementCtrl:ButtonMenu()

end


function A_SettlementCtrl:Unload()
  for i=1, #A_ViewNames do
      package.loaded[A_ViewNames[i]] = nil
  end
 -- print("卸载视图层脚本成功")

  for i=1, #A_CtrlNames do
      package.loaded[A_CtrlNames[i]] = nil
  end
  package.loaded["A_StartGame"]=nil
  package.loaded["A_CtrlMgr"]=nil
--  print("卸载控制层脚本成功")
end

