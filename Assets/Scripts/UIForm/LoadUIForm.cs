using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;
public class LoadUIForm : BaseUIForm
{
    private void Awake()
    {
        base.CurrentUIType.UIForms_Type = UIFormType.Normal;
        base.CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
    }
}
