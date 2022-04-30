using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class cheat : MonoBehaviour
{
    string x;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StreamReader GoldenTie = new StreamReader("Assets/Musor/Data.txt");
            x = GoldenTie.ReadLine();
            GoldenTie.Close();
            StreamWriter writer = new StreamWriter("Assets/Musor/Data.txt");
            writer.WriteLine(Convert.ToInt32(x) + 1000);
            writer.Close();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StreamWriter writer = new StreamWriter("Assets/Musor/Data.txt");
            writer.WriteLine(0);
            writer.Close();

        }
    }
}
