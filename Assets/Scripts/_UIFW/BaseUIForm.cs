/***
 *          定义所有UI窗体的父类
 */
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace UIFW
{
	public class BaseUIForm : MonoBehaviour {

        private UIType _CurrentUIType=new UIType();

        //UI窗体类型
	    public UIType CurrentUIType
	    {
	        get { return _CurrentUIType; }
	        set { _CurrentUIType = value; }
	    }


        #region  窗体的四种(生命周期)状态
	    public virtual void Display()           // 显示状态
        {
	        this.gameObject.SetActive(true);
            this.transform.SetAsLastSibling();
            if (_CurrentUIType.UIForms_Type==UIFormType.PopUp)
            {
                UIMaskMgr.GetInstance().SetMaskWindow(this.gameObject);
            }
	    }

	    public virtual void CloseUI()        // 隐藏状态
        {
            this.gameObject.SetActive(false);
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskMgr.GetInstance().CancelMaskWindow();
            }
        }
        #endregion

        #region 封装子类常用的方法

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgType">消息的类型</param>
        /// <param name="msgName">消息名称</param>
        /// <param name="msgContent">消息内容</param>
	    public void SendMessage(string msgType,string msgContent)
	    {
            MessageCenter.SendMessage(msgType, msgContent);
            
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="messagType">消息分类</param>
        /// <param name="handler">消息委托</param>
	    public void ReceiveMessage(string messagType,MessageCenter.DelMessageDelivery handler)
	    {
            MessageCenter.AddMsgListener(messagType, handler);
          
	    }
	    #endregion

    }
    public class UIType
    {
        //UI窗体（位置）类型
        public UIFormType UIForms_Type = UIFormType.Normal;
        //UI窗体显示类型
        public UIFormShowMode UIForms_ShowMode = UIFormShowMode.Normal;
    }
}