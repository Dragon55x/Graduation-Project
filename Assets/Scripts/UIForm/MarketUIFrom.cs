
// 防御塔列表窗体  

using System.Collections;
using System.Collections.Generic;
using UIFW;
using UnityEngine;

namespace DemoProject
{
    public class MarketUIFrom : BaseUIForm
    {
		void Awake ()
        {
		    //窗体性质
		    CurrentUIType.UIForms_Type = UIFormType.PopUp;  //弹出窗体    
        }
	}
}