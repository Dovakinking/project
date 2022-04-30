using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    public float [] mas = new float[3];
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        StreamReader save = new StreamReader("Assets/Musor/Save.txt");
        string x = save.ReadLine();
        save.Close();
        string [] line = x.Split(' ');
        for(int i = 0; i < line.Length; i++)
        {
            mas[i] = float.Parse(line[i]);
            Debug.Log(mas[i]);
        }
        player1.transform.position = new Vector3(mas[0], mas[1], mas[2]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            Saving();
    }
    public void Saving()
    {
        StreamWriter saving = new StreamWriter("Assets/Musor/Save.txt");
        saving.WriteLine(player2.transform.position.x.ToString()+ " " + player2.transform.position.y.ToString() + " " + player2.transform.position.z.ToString());
        saving.Close();
    }
}
