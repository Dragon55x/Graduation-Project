
using System.Collections;
using System.Collections.Generic;
using ABFW;
using LuaFramework;
using UIFW;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DemoProject
{
    public class MainCityUIForm : BaseUIForm
    {
		public void Awake () 
        {
	        //窗体性质
		    CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;

        }
		
	}
}