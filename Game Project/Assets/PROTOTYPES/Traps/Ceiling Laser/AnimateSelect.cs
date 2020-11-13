using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSelect : MonoBehaviour
{

    public bool A;
    public bool B;

    public Animator animator;

void Start()
    {
        if (A == true)
        {
            animator.SetBool("A", true);
        }


        if (B == true)
        {
            animator.SetBool("B", true);
        }
    }
}
