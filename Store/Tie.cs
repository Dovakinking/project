using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class Tie : MonoBehaviour
{
    public GameObject buyTie;
    void Update()
    {
        StreamReader reader = new StreamReader("Assets/Musor/Buy/Tie.txt");
        string s = reader.ReadLine();
        buyTie.SetActive(Convert.ToBoolean(s));
        reader.Close();
    }
}
