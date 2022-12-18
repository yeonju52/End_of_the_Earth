using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor_Rotation : MonoBehaviour
{
    Animator Anim;
    bool flag;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 1.0f;
        flag = true;

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.V) && other.tag == "Player")
        {
            if (flag)
            {
                Anim.speed = 0f;
                flag = false;
            }
            else
            {
                Anim.speed = 1.0f;
                flag = true;

            }
        }
    }
}
