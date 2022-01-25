--对象池管理类



PrefabObjectPool={}
PrefabObjectPool.__index = PrefabObjectPool

function PrefabObjectPool:New()
	local self = {}
	setmetatable(self,PrefabObjectPool)
	self.List = {}
	self.ListCount=0
	-- self.usedItems 
	-- self.capcity = capcity
	return self
end

local EnemyBornPosition=nil

----------------------------------------拿到物体--------------------
--拿到物体Get
function PrefabObjectPool:Get(ObjName)
	--初始化返回物体为nil
	local obj = nil
	--物体在场景中的实际名字
	local Truename=ObjName.."(Clone)"

	--如果列表存有量为0，则新生成
	if self.ListCount == 0 then
		obj = GameObject.Instantiate(A_CtrlMgr.abDTObj:PrefabAB(ObjName))
		--print("池子里面没东西，新建：。。。。。。。。。。。。。。。")
	--列表种有对象
	else
		--如果找到目标对象，返回
		for i,v in pairs(self.List) do
			if(v.name==Truename) then
				--获得对象
				obj=v
				obj:SetActive(true)
				--从对象池种移除
				table.remove(self.List,i)
				--对象池数量-1
				self.ListCount=self.ListCount-1
				--print("池子里面有，拿到了。。。。。。。。。。")
				return obj
			end
		end
		--没找到，生成对象
		obj=GameObject.Instantiate(A_CtrlMgr.abDTObj:PrefabAB(ObjName))
		--print("池子里没这个类型的，新建。。。。。。。。。。。。。。。。。")
	end

	obj:SetActive(true)
	return obj
end

--敌人生成定制版Get
function PrefabObjectPool:GetEnemy(ObjName,StartPosition)
	EnemyBornPosition=StartPosition
	--初始化返回物体为nil
	local obj = nil
	--物体在场景中的实际名字
	local Truename=ObjName.."(Clone)"

	--如果列表存有量为0，则新生成
	if self.ListCount == 0 then
		obj = GameObject.Instantiate(A_CtrlMgr.abDTObj:PrefabAB(ObjName),StartPosition.transform.position,CSU.Quaternion.identity)
		--print("池子里面没东西，新建：。。。。。。。。。。。。。。。")
	--列表种有对象
	else
		--如果找到目标对象，返回
		for i,v in pairs(self.List) do
			if(v.name==Truename) then
				--获得对象
				obj=v
				obj:SetActive(true)
				obj.transform.position=StartPosition.transform.position
				--从对象池种移除
				table.remove(self.List,i)
				--对象池数量-1
				self.ListCount=self.ListCount-1
				--print("池子里面有，拿到了。。。。。。。。。。")
				return obj
			end
		end
		--没找到，生成对象
		obj = GameObject.Instantiate(A_CtrlMgr.abDTObj:PrefabAB(ObjName),StartPosition.transform.position,CSU.Quaternion.identity)
		--print("池子里没这个类型的，新建。。。。。。。。。。。。。。。。。")
	end

	obj:SetActive(true)
	return obj
end

------------------------回收物体-----------------------------


-- 回收一个对象到对象池
function PrefabObjectPool:Put(obj)
	--禁用
	obj:SetActive(false)
	--列表大小+1
	self.ListCount=self.ListCount+1
	--插入对象池
	table.insert(self.List,obj)
	-- print("回收成功。。。。。。。。。。。。。")
end
--敌人回收
function PrefabObjectPool:PutEnemy(obj)
	--禁用
	obj:SetActive(false)
	--放回开始位置
	obj.transform.position=EnemyBornPosition.transform.position
	--列表大小+1
	self.ListCount=self.ListCount+1
	--插入对象池
	table.insert(self.List,obj)
	--print("回收成功。。。。。。。。。。。。。")
end
--敌人血条UI回收定制版PutUI
function PrefabObjectPool:PutUI(obj)
	--恢复状态
	--obj.transform:Find("HpSlider"):GetComponent("UnityEngine.UI.Slider").value=1
	--禁用
	obj:SetActive(false)
	--列表大小+1
	self.ListCount=self.ListCount+1
	--插入对象池
	table.insert(self.List,obj)
	--print("回收成功。。。。。。。。。。。。。")
end
--炮塔回收PutTurret
function PrefabObjectPool:PutTurret(obj)
	--插入对象池
	table.insert(self.List,obj)
	--恢复状态
	obj.transform:Find("Partical").gameObject:SetActive(false)
	--禁用
	obj:SetActive(false)
	--列表大小+1
	self.ListCount=self.ListCount+1
	--print("回收成功。。。。。。。。。。。。。")
end


-- 将所有被使用的对象全部回收
function PrefabObjectPool:RecycleAll()
	local count = self.usedItems.Count
	for i=count-1,0, -1 do
		local item = self.usedItems[i]
		self:Put(item)
	end
	self.usedItems:Clear()
end

--清空对象池Destroy
function PrefabObjectPool:Clear()

	self:RecycleAll();

	for i = 0, self.List.Count - 1 do
		GameObject.Destroy(self.List:Dequeue());
	end

	self.List:Clear();
end

