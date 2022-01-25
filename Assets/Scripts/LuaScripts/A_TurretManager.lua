
--炮塔实例行为管理
A_TurretManager={}
A_TurretManager.DefenseList = {}


function A_TurretManager.Update()
   for i,v in pairs(A_TurretManager.DefenseList) do
      if(v.gameObject~=nil) then
         v:Update()
      end
   end
end
function A_TurretManager:Remove(ClassObj)
   A_TurretManager.DefenseList[ClassObj.IndexSelf]=nil
end



