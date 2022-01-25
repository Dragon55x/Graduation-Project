Z_Observer={}   --抽象基类

-- 名称
Z_Observer.name=""

function Z_Observer:new(_o)
   _o = _o  or {}
   setmetatable(_o,self)
   self.__index=self
   return _o
end

-- 动作
-- function Observer:run()
--     print(self.name.."do something")
-- end
