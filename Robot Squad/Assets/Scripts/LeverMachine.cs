using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMachine : MonoBehaviour
{
    public GameObject offSprite;
    public GameObject onSprite;
    bool activated;
    bool onOff;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        onOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onOff)
        {
            onSprite.SetActive(true);
            offSprite.SetActive(false);
        }
        else
        {
            onSprite.SetActive(false);
            offSprite.SetActive(true);
        }
    }

    public void ActivateLever()
    {
        activated = true;
    }


    public void ToggleOnOff() 
    {
        if (activated)
        {
            if (onOff)
            {
                onOff = false;
            }
            else
            {
                onOff = true;
            }
            ActionBasedOnItem();
        }
    }


    void ActionBasedOnItem()
    {
        Elevator elevator = GetComponentInChildren<Elevator>();
        if (elevator != null)
        {
            elevator.enabled = !elevator.enabled;
        }


    }
}
