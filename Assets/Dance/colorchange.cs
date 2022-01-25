using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class colorchange : MonoBehaviour
{
    Light lightq;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        lightq = this.GetComponent<Light>();
        renderer = this.GetComponent<Renderer>();
        StartCoroutine(Changeblood());
    }

    IEnumerator Changeblood()
    {
        int i = 1;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.4f);
            lightq.color = new Color(Random.Range(50, 255) / 255f, Random.Range(50, 255) / 255f, Random.Range(50, 255) / 255f);
            renderer.material.color = lightq.color;
            
            lightq.intensity = Random.Range(0.1f, 3f);
        }
    }


}
