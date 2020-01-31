using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject offSprite;
    public GameObject onSprite;
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLever()
    {
        activated = true;
    }


    void ToggleOnOff() 
    { }


    void ActionBasedOnItem()
    {
        if (activated)
        {
            Elevator elevator = GetComponentInChildren<Elevator>();
            if (elevator != null)
            {
                elevator.enabled = !elevator.enabled;
            }

            Circular[] circulars = GetComponentsInChildren<Circular>();
            foreach (Circular c in circulars)
            {
                c.enabled = !c.enabled;
            }
        }
    }
}
