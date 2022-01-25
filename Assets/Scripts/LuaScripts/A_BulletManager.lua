
--子弹实例管理类

A_BulletManager={}
--子弹实例
A_BulletManager.Bulletlist={}
--子弹对象池
A_BulletManager.BulletPool={}

-- function A_BulletManager.Start()
   -- --子弹对象池初始化
   -- for i,10 do
   --    local bullet=CSU.Object.Instantiate(self.Bullet,self.FirePosition.position,self.FirePosition.rotation)
   --    local BulletObj=A_BulletAB:New(bullet,self.damage,self.BulletSpeed)
   -- end
-- end

function A_BulletManager.Update()
   for i,v in pairs(A_BulletManager.Bulletlist) do
      if(v~=nil) then
   	  v:Update()
      end
   end
end


function A_BulletManager:Remove(ClassObj)
   A_BulletManager.Bulletlist[ClassObj.IndexSelf]=nil
end