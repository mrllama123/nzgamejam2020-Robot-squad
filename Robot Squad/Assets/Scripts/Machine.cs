using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public Item.Type itemNeeded = Item.Type.Gear;
    public Transform itemSlot;

    Item itemInSlot;

    public bool InsertItem(Item item)
    {
        if (item == null)
        {
            print("oops item is null");
            return false;
        }


        if (itemInSlot == null && itemNeeded == item.type)
        {
            itemInSlot = item;
            item.machine = this;
            if (itemSlot != null)
            {
                item.transform.position = itemSlot.transform.position;
            }
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
        itemInSlot = null;
        ActionBasedOnItem();
    }

    public void ActionBasedOnItem()
    {
        Elevator elevator = GetComponentInChildren<Elevator>();
        if (elevator != null)
        {
            elevator.enabled = !elevator.enabled;
        }

        Bridge bridge = GetComponentInChildren<Bridge>();
        if(bridge != null)
        {
            bridge.Toggle();
        }


        Circular[] circulars = GetComponentsInChildren<Circular>();
        foreach (Circular c in circulars)
        {
            c.enabled = !c.enabled;
        }

    }

}
