using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class Jump : MonoBehaviour
{
    public GameObject buyJump;
    void Update()
    {
        StreamReader reader = new StreamReader("Assets/Musor/Buy/Jump.txt");
        string s = reader.ReadLine();
        buyJump.SetActive(Convert.ToBoolean(s));
        reader.Close();
    }
}
