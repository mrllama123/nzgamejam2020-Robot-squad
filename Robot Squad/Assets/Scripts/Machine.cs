using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public Item.Type itemNeeded = Item.Type.Gear;
    public Transform itemSlot;

    public bool InsertItem(Item item)
    {
        if (item == null)
        {
            print("oops item is null");
            return false;
        }


        if (itemNeeded == item.type)
        {
            item.machine = this;
            item.transform.position = itemSlot.transform.position;
            item.transform.SetParent(itemSlot);
            ActionBasedOnItem();

            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveItem()
    {
        ActionBasedOnItem();
    }

    public void ActionBasedOnItem()
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
