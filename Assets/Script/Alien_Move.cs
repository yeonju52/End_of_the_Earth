using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Move : MonoBehaviour
{
    public GameObject target;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 0.5f))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.5f);

            transform.LookAt(target.transform);
            //Debug.Log(Vector3.MoveTowards(transform.position, target.transform.position, 1f));

            animator.SetBool("off", false);
        }
        else
        {
            animator.SetBool("off", true);
        }
    }
}