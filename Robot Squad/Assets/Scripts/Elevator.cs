using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator.enabled = false;
    }
}
