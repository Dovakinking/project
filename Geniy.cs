using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geniy : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    private bool x = false;
    private bool y = true;
    public Camera cam;
    public void bool_x()
    {
        x = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (x == true)
            {
                cam.rect = new Rect(0f, 0f, 1f, 1f);
                cam1.SetActive(false);
                cam2.SetActive(true);
                x = false;
                Debug.Log("a");
            }
            else
            {
                cam.rect = new Rect(0.05f, 0.05f, 0.2f, 0.2f);
                cam1.SetActive(true);
                cam2.SetActive(false);
                x = true;
                Debug.Log("b");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && x == true)
        {
            if (y == true)
            {
                cam.rect = new Rect(0f, 0f, 1f, 1f);
                y = false;
            }
            else
            {
                cam.rect = new Rect(0.05f, 0.05f, 0.2f, 0.2f);
                y = true;
            }
        }
    }
}