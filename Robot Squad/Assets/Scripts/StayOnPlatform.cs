using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    public LayerMask layerMask;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (layerMask == (layerMask | (1 << collision.transform.gameObject.layer)))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (layerMask == (layerMask | (1 << collision.transform.gameObject.layer)))
        {
            transform.parent = null;
        }
    }
}
