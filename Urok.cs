using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Urok : MonoBehaviour
{
    int intToSave;
    public void Start()
    {
        StreamReader reader = new StreamReader("Assets/Musor/Data.txt");
        string s = reader.ReadLine();
        intToSave = Convert.ToInt32(s);
        reader.Close();
        Collector.count = intToSave;
    }
    public void OnGUI()
    {
        GUI.Label(new Rect(500, 50, 500, 400), "Saved Coins:" + Collector.count);
    }

}
