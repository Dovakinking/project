using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Escape : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    private bool x = false;
    public void bool_x()
    {
        x = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (x == true)
            {
                one.SetActive(false);
                two.SetActive(true);
                three.SetActive(true);
                x = false;
                Debug.Log("a");
            }
            else
            {
                one.SetActive(true);
                two.SetActive(false);
                three.SetActive(false);
                x = true;
                Debug.Log("b");
            }
        }

    }
}
