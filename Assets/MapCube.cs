using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    public Material materialSlected;
    public Material materialOrigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        if (gameObject.layer==8&& EventSystem.current.IsPointerOverGameObject() == false)
        {
            GetComponent<Renderer>().material = materialSlected;
        }
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = materialOrigin;
    }
}
