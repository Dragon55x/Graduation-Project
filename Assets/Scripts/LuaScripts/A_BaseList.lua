
A_BaseList={}
A_BaseList.__index=A_BaseList
function A_BaseList:New()
	local temp={}
	setmetatable(temp,A_BaseList)
	temp.Data={}
	return temp
end

--添加元素 尾部插入
function A_BaseList:Add(item) 
    table.insert(self.Data, item)
end

--是否包含某个物体（不为nil），true or false
function A_BaseList:Contains(item)
	for i,v in pairs(self.Data) do
		if self.Data[i] == item then
			return true
		end
	end
	return false
 end
 
 --返回列表中某个物体的下标，没有则返回nil
 function A_BaseList:Find(item,count)
	local index=0
	for i=1,count do
	   if(self.Data[i]==item) then
		  index=i
		  return index
	   end
	end
	return nil
 end

--按数据删除元素
 function A_BaseList:FindDelete(item,count)
    local index=self:Find(item,count)
		if(index~=nil) then
			table.remove(self.Data,index)
		end
 end
--按下标删除元素
function A_BaseList:Remove(index)
    table.remove(self.Data,index)
end
 