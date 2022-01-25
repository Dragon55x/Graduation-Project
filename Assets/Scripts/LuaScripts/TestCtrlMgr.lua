---
---  “lua框架”项目中控制层管理器
---
---  功能：
---     1：缓存所有项目中控制层lua脚本。
---     2：提供访问项目中所有控制层lua脚本的入口函数
---

--引入控制层管理器脚本
require("DefenseListCtr")


TestCtrlMgr={}
local this=TestCtrlMgr
--定义一个控制器列表（缓存所有项目中用到的所有控制层lua脚本）
local ctrlList={}

--lua 控制器初始化(缓存所有项目中控制层lua脚本)
function TestCtrlMgr.Init()
    ctrlList[CtrlName.DefenseListCtr]=DefenseListCtr.GetInstance() --得到脚本的实例
  
end

--获取控制器lua脚本
function TestCtrlMgr.GetCtrlInstance(ctrlName)
    return ctrlList[ctrlName]
end

--获取控制器lua脚本实例，且调用StartProcess函数。
function TestCtrlMgr.StartProcess(ctrlName)
    local ctrlObj=TestCtrlMgr.GetCtrlInstance(ctrlName)

    if(ctrlObj~=nil) then
        print(ctrlName)
        ctrlObj.StartProcess()
        
    end
end


















