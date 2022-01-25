using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFW;
public class GameHall : MonoBehaviour
{
    void Start()
    {
        UIManager.GetInstance().ShowUIForms("MainCityUIForm");
        UIManager.GetInstance().ShowUIForms("HeroInfoUIForm");
    }
}
