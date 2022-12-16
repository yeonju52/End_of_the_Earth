using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Move : MonoBehaviour
{
    public float Speed = 0.01f;

    int i = 0;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 270 : 1080 = 1 : 4
        if(i % 1350 <= 270)
        {   // 270
            animator.SetBool("off", true);
        }
        else // walk
        {   // 1080
            if (i % 1350 > 1170) // 1350 - 90 * 2
                transform.Rotate(0, 0.5f, 0);
            animator.SetBool("off", false);
            transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
        }
        //Debug.Log(i);
        i++;
    }
}