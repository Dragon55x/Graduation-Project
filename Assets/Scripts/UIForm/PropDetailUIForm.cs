                 
//防御塔详细信息窗体  

using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UIFW;
using UnityEngine;
using UnityEngine.UI;

namespace DemoProject
{
	public class PropDetailUIForm : BaseUIForm
	{
        MessageCenter.DelMessageDelivery del;
        public Text Txt;                                //窗体显示

		void Awake () 
        {
		    //窗体的性质
		    CurrentUIType.UIForms_Type = UIFormType.PopUp;
            del = ShowDetail;
            /*  接受信息   */
            ReceiveMessage("Detail", del);

        }
        public void ShowDetail(string p)
        {
            Debug.Log("ShowDetail");
            if (Txt)
            {
                string strArray = p;
                Txt.text = strArray;
            }
        }
		
	}
}