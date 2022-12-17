using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Move : MonoBehaviour
{
    public GameObject parent;
    public GameObject target;
    private Animator animator;
    private int i = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = parent.transform.GetChild(i % 3).gameObject;
        Debug.Log(target);
    }

    void Update()
    {
        target = parent.transform.GetChild(i % 3).gameObject;
        target.SetActive(true);
        Debug.Log(i);
        if (i / 3 > 3)
        {
            animator.SetBool("off", true);
            i++;
        }
        else
        {
            if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 0.01f))
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);

                transform.LookAt(target.transform);
                //Debug.Log(Vector3.MoveTowards(transform.position, target.transform.position, 0.1f));

                animator.SetBool("off", false);
            }
            else
            {
                target.SetActive(false);
                i++;
            }
        }
    }
}

/*
    if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 0.1f))
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);

        transform.LookAt(target.transform);
        //Debug.Log(Vector3.MoveTowards(transform.position, target.transform.position, 0.1f));

        animator.SetBool("off", false);
    }
    else
    {
        animator.SetBool("off", true);
} 
 */