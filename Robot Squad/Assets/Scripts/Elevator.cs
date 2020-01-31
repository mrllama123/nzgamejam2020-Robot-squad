using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform top, bottom;
    
    float speed = 3;
    Vector2 topPos, bottomPos;
    bool goingUp = true;

    private void Start()
    {
        topPos = top.transform.position;
        bottomPos = bottom.transform.position;
    }

    private void Update()
    {
        if (goingUp)
        {
            if (Vector2.Distance(transform.position, topPos) > .2f)
            {
                transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
            else
            {
                goingUp = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, bottomPos) > .2f)
            {
                transform.Translate(Vector2.down * Time.deltaTime * speed);
            }
            else
            {
                goingUp = true;
            }
        }
    }


    //public Animator animator;

    //private void Start()
    //{
    //    animator.enabled = false;
    //}
}
