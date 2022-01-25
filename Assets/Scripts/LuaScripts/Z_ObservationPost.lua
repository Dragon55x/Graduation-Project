--require("Z_Observer")

--被观察者类
Z_ObservationPost={}


function Z_ObservationPost:new(_o)
   _o = _o  or {}
   setmetatable(_o,self)
   self.__index=self
   return _o
end

--观察者列表 
Z_ObservationPost.ObserverList={}

--增加观察者
function Z_ObservationPost:add(_obs)
    if self.ObserverList == nil then
        self.ObserverList={} 
    end
    table.insert(self.ObserverList,_obs)
end

 --删除观察者
function Z_ObservationPost:delete(_obs)
    for k, v in pairs(self.ObserverList) do
		if v == _obs then
			table.remove(self.ObserverList,k)
			break
		end
	end
end

--消息通知
function Z_ObservationPost:Notify()
    for k,v in ipairs(self.ObserverList) do 
        local obs=self.ObserverList[k]
        if(k) then
            obs:UpgradeCoinUI()
        end
    end
end
