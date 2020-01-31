using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Gear,
        Gold,
        Screw,
        Copper,
        Antenna,
        Water,
        Chip,
        Computer
    }

    public Type type;
    public Machine machine;
}
