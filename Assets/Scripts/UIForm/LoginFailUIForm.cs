
//登录失败窗体                    

using System.Collections;
using System.Collections.Generic;
using UIFW;
using UnityEngine;
using UnityEngine.UI;

namespace DemoProject
{
    public class LoginFailUIForm : BaseUIForm
    {
        public void Awake()
        {
            CurrentUIType.UIForms_Type = UIFormType.PopUp;  //弹出窗体   
        }
    }
}