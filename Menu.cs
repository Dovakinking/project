using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu: MonoBehaviour
{
    private string x;
    private string y;

    public void PlayPressed()
    {
        StreamReader GoldenTie = new StreamReader("Assets/Musor/Buy/GoldenTie.txt");
        x = GoldenTie.ReadLine();
        GoldenTie.Close();

        StreamReader Jump = new StreamReader("Assets/Musor/Buy/Jump.txt");
        y = Jump.ReadLine();
        Jump.Close();
        if (x == "True" && y == "True")
            SceneManager.LoadScene("Game11");
        else if (x == "false" && y == "True")
            SceneManager.LoadScene("Game01");
        else if (x == "True" && y == "false")
            SceneManager.LoadScene("Game10");
        else if (x == "false" && y == "false")
            SceneManager.LoadScene("Game00");

    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
