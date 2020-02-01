using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform top, bottom;
    public bool hortizontal;
    
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
        if (hortizontal)
        {
            Horizontal();
        }
        else
        {
            Vertical();
        }
    }

    private void Horizontal()
    {
        if (goingUp)
        {
            if (Vector2.Distance(transform.position, topPos) > .5f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            else
            {
                goingUp = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, bottomPos) > .5f)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
            else
            {
                goingUp = true;
            }
        }
    }

    private void Vertical()
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
}
