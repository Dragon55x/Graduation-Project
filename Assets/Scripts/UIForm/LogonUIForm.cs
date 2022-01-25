
using System.Collections;
using System.Collections.Generic;
using UIFW;
using UnityEngine;
using UnityEngine.UI;

namespace DemoProject
{
    public class LogonUIForm : BaseUIForm
    {

        public void Awake()
        {
            base.CurrentUIType.UIForms_Type = UIFormType.Normal;
            base.CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
            
        }

    }
}