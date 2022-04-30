using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class GoldenTie : MonoBehaviour
{
    public GameObject buyGoldenTie;
    void Update()
    {
        StreamReader reader = new StreamReader("Assets/Musor/Buy/GoldenTie.txt");
        string s = reader.ReadLine();
        buyGoldenTie.SetActive(Convert.ToBoolean(s));
        reader.Close();
    }
}
