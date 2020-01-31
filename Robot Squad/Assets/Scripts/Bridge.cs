using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    public GameObject[] bridges;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        if(bridges != null)
        {
            foreach(GameObject bridge in bridges)
            {
                bridge.SetActive(!bridge.activeInHierarchy);
            }
            
       }
    }   
}
