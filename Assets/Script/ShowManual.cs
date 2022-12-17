using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowManual : MonoBehaviour
{
    public GameObject ui;
    private int turn = 0;
    private AudioSource audio;
    private GameObject player;
    //AudioSource audio = GetComponent<AudioSource>();
    //AudioSource audio = GetComponent<AudioSource>();

    void Start()
    {
        audio = GetComponent<AudioSource>();
        ui.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ¶ì¸µ
        audio.Play();

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("u") && other.tag == "Player")
        {
            if (turn == 0)
            {
                ui.SetActive(true);
                turn = 1;
            }
            else
            {
                ui.SetActive(false);
                turn = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
        turn = 0;
    }
}