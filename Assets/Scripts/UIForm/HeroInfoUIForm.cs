
using System.Collections;
using System.Collections.Generic;
using UIFW;
using UnityEngine;

namespace DemoProject
{
	public class HeroInfoUIForm : BaseUIForm {


		void Awake () 
        {
		    //窗体性质
            CurrentUIType.UIForms_Type = UIFormType.Fixed;  //固定在主窗体上面显示

        }
		
	}
}