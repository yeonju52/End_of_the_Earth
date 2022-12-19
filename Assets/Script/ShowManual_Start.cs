using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowManual_Start : MonoBehaviour
{
    public GameObject ui;
    private int turn = 0;
    private AudioSource beep;
    private GameObject player;

    private void Start()
    {
        ui.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown("u"))
        {
            ui.SetActive(false);
        }
    }
}