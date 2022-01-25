using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public GameObject sliderCanvas;
    //public Slider slider;
    //public float TotalHp;
    //public float CurrentHp;
    //private void Start()
    //{
    //    //sliderCanvas = new Canvas();
    //   // slider = sliderCanvas.transform.Find("HpSlider").GetComponent<Slider>();
    //}
    ////传入对应的血条UI
    //public void GetUpcanvas(GameObject CanObj)
    //{
        
    //    sliderCanvas = CanObj;
    //}

    //public void GetHp(float total)
    //{
        
    //    TotalHp = total;
    //    CurrentHp = total;
    //}

    //public void Takedamage(float damage)
    //{
    //    if (CurrentHp <= 0)
    //        return;

    //    CurrentHp -= damage;
    //    //Debug.Log("伤害：   "+damage+"当前血量：  "+CurrentHp);
    //    slider.value = (float)CurrentHp / TotalHp;
    //    //Debug.Log(slider.value);
       
    //}
    ////void Die()
    ////{
    ////    //GameObject effect = GameObject.Instantiate(ExplosionEffect, transform.position, transform.rotation);
    ////    //Destroy(effect, 1.5f);
    ////    Destroy(this.gameObject);
    ////}

    //public GameObject SendCanvasToLua()
    //{
    //    return sliderCanvas;
    //}

    //public float SendCurrentHpToLua()
    //{
    //    return CurrentHp;
    //}

    //public void CloseEnemy()
    //{
    //    this.gameObject.SetActive(false);
    //    this.sliderCanvas.SetActive(false);
    //    //Destroy(this.gameObject);
    //    //Destroy(this.sliderCanvas);
    //}
}
