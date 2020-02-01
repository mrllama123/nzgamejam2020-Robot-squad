using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{
    public GameObject anchor;
    float speed = 50;

    void LateUpdate()
    {
        transform.RotateAround(anchor.transform.position, Vector3.back, Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
