
//注册窗体   

using System.Collections;
using System.Collections.Generic;
using UIFW;
using UnityEngine;
using UnityEngine.UI;

namespace DemoProject
{
    public class ResUIForm : BaseUIForm
    {
        

        public void Awake()
        {
            CurrentUIType.UIForms_Type = UIFormType.PopUp;  //弹出窗体   
          

            //var t1 = UnityHelper.FindTheChildNode(this.transform.gameObject, "InputID");//id
            //var t2 = UnityHelper.FindTheChildNode(this.transform.gameObject, "InputName");//name
            //var t3 = UnityHelper.FindTheChildNode(this.transform.gameObject, "InputPaw");//pas
            //var t4 = UnityHelper.FindTheChildNode(this.transform.gameObject, "ResButton");
            //Button btnreg = t4.gameObject.GetComponent<Button>();
            ////Login.LogIn(t1.Find("Text").GetComponent<Text>().text, t2.Find("Text").GetComponent<Text>().text);
            //btnreg.onClick.AddListener(() => LoginRes.Savegame.SaveGame(t1.Find("Text").GetComponent<Text>().text, t2.Find("Text").GetComponent<Text>().text, t3.Find("Text").GetComponent<Text>().text, 0, null));


        }

    }
}