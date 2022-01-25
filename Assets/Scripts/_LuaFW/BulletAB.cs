using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAB : MonoBehaviour
{
    private float timer = 0;

    private void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 1.2f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
