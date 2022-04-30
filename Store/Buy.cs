using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Buy : MonoBehaviour
{
    private int Tie = 50;
    public GameObject SoldTie;
    private int GoldenTie = 150;
    public GameObject SoldGoldenTie;
    private int Jump = 100;
    public GameObject SoldJump;
    public string G;
    public string J;
    public string T;
    public int c;
    private void Update()
    {

        StreamReader GoldenTie = new StreamReader("Assets/Musor/Buy/GoldenTie.txt");
        G = GoldenTie.ReadLine();
        GoldenTie.Close();

        StreamReader Jump = new StreamReader("Assets/Musor/Buy/Jump.txt");
        J = Jump.ReadLine();
        Jump.Close();

        StreamReader Tie = new StreamReader("Assets/Musor/Buy/Tie.txt");
        T = Tie.ReadLine();
        Tie.Close();

        StreamReader reader = new StreamReader("Assets/Musor/Data.txt");
        c = Convert.ToInt32(reader.ReadLine());
        reader.Close();

    }
    public void OnGUI()
    {
        GUI.Label(new Rect(375, 0, 125, 50), "Coins:" + c);
    }

    public void BuyTie()
    {
        StreamReader reader = new StreamReader("Assets/Musor/Data.txt");
        int x = Convert.ToInt32(reader.ReadLine());
        reader.Close();
        Debug.Log(x);
        if (x >= Tie && Convert.ToBoolean(T) == false)
        {
            StreamWriter writer = new StreamWriter("Assets/Musor/Buy/Tie.txt");
            writer.WriteLine(true);
            writer.Close();
            StreamWriter coin = new StreamWriter("Assets/Musor/Data.txt");
            int y = x - Tie;
            Debug.Log("Tie " + y);
            coin.WriteLine(y);
            coin.Close();
            SoldTie.SetActive(true);
        }

    }
    public void BuyGoldenTie()
    {
        
        StreamReader reader = new StreamReader("Assets/Musor/Data.txt");
        int x = Convert.ToInt32(reader.ReadLine());
        Debug.Log(x);
        reader.Close();
        if (x >= GoldenTie && Convert.ToBoolean(G) == false)
        {
            StreamWriter writer = new StreamWriter("Assets/Musor/Buy/GoldenTie.txt");
            writer.WriteLine(true);
            writer.Close();
            StreamWriter coin = new StreamWriter("Assets/Musor/Data.txt");
            int y = x - GoldenTie;
            Debug.Log("GoldenTie " + y);
            coin.WriteLine(y);
            coin.Close();
            SoldGoldenTie.SetActive(true);
        }
    }
    public void BuyJump()
    {
        
        StreamReader reader = new StreamReader("Assets/Musor/Data.txt"); 
        int x = Convert.ToInt32(reader.ReadLine());
        reader.Close();
        Debug.Log(x);
        if (x >= Jump && Convert.ToBoolean(J) == false)
        {
            StreamWriter writer = new StreamWriter("Assets/Musor/Buy/Jump.txt");
            writer.WriteLine(true);
            writer.Close(); 
            StreamWriter coin = new StreamWriter("Assets/Musor/Data.txt");
            int y = x - Jump;
            Debug.Log("Jump " + y);
            coin.WriteLine(y);
            coin.Close();
            SoldJump.SetActive(true);
        }
    }
}
