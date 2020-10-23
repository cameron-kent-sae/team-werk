using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;

    private void Start()
    {
        //attach sound effect for button
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horiontal") != 0)
        {
            //Check if player inputs 'left' direction input
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (index < maxIndex)
                {
                    index++;
                } else
                {
                    index = 0;
                }
            }             
            //Check if player inputs 'right' direction input
            else if (Input.GetAxis("Horizontal") > 0)
            {
                if (index > 0)
                {
                    index--;
                } else
                {
                    index = maxIndex;
                }
            }
            keyDown = true;
        } else
        {
            keyDown = false;
        }
    }
}
