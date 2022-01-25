/***
 * 
 *    Title: "SUIFW" UI框架项目
 *           主题： 消息（传递）中心
 *    Description: 
 *           功能： 负责UI框架中，所有UI窗体中间的数据传值。
 *                  
 *    AddMsgListener   在_dicMessages中添加委托等待接受消息  
 *    SendMessage 向消息中心发来数据，去_dicMessages中查找并执行委托
 *   
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFW
{
	public class MessageCenter {
        //委托：消息传递
	    public delegate void DelMessageDelivery(string kv);

        //消息中心缓存集合
        //<string : 数据大的分类，DelMessageDelivery 数据执行委托>
	    public static Dictionary<string, DelMessageDelivery> _dicMessages = new Dictionary<string, DelMessageDelivery>();


	    public static void AddMsgListener(string messageType,DelMessageDelivery handler)       // 增加消息的监听。
		{

			if (!_dicMessages.ContainsKey(messageType))
	        {

                _dicMessages.Add(messageType,null);
            }
	        _dicMessages[messageType] += handler;
	    }

	    public static void RemoveMsgListener(string messageType,DelMessageDelivery handele)     // 取消消息的监听
		{
            if (_dicMessages.ContainsKey(messageType))
            {
                _dicMessages[messageType] -= handele;
            }

	    }

	    public static void ClearALLMsgListener()        // 取消所有消息的监听
        {
	        if (_dicMessages!=null)
	        {
	            _dicMessages.Clear();
            }
	    }

	    public static void SendMessage(string messageType, string kv)       // 发送消息
        {
	        DelMessageDelivery del;                         //委托

			Debug.Log(messageType);
			if (_dicMessages.TryGetValue(messageType,out del))
	        {
	            if (del!=null)
	            {
                    //调用委托
	                del(kv);
	            }
	        }
           
	    }
	}

   


}