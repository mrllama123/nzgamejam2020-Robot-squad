using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFieldToggler : MonoBehaviour
{
    public GameObject GravityFieldCollider;

    public void Toggle()
    {
        if (GravityFieldCollider != null)
        {
            GravityFieldCollider.SetActive(!GravityFieldCollider.activeInHierarchy);
        }
    }
}
