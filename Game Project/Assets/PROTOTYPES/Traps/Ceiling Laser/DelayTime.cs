using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTime : MonoBehaviour
{

    public float time;

    [Range(0f, 5f)]
    public float delayTime; //Delay time

    public Animator animator;


    void Update()
    {
        animator.SetFloat("time", time);
        time -= 1 * Time.deltaTime;
        if (time <= 0)
        {
            time = delayTime;
        }
    }

}
