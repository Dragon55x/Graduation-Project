-- require  ("Z_ConcreteObserver") 
-- require  ("Z_ObservationPost")

local function main()
    -- 初始化 两个观察者
    local a=Z_ConcreteObserver:new()
    a.name="Z_ConcreteObserver_1 "
    local b=Z_ConcreteObserver:new()
    b.name="Z_ConcreteObserver_2 "
    
    --创建被观察对象
    obs=Z_ObservationPost:new()

    --将观察者添加到列表
    obs:add(a)
    obs:add(b)

    -- 被观察者 通知所有观察者
    obs:Notify()
end

main()
