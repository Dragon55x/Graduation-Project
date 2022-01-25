--敌人行为管理类

A_EnemyManager={}
A_EnemyManager.EnemySelfList={}


function A_EnemyManager.Update()
    for i,v in pairs(A_EnemyManager.EnemySelfList) do
      v:Update()
   end
end


function A_EnemyManager:Remove(ClassObj)
   A_EnemyManager.EnemySelfList[ClassObj.IndexSelf]=nil
end