using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Return : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        StreamWriter GoldenTie = new StreamWriter("Assets/Musor/Buy/GoldenTie.txt");
        GoldenTie.WriteLine("false");
        GoldenTie.Close();

        StreamWriter Jump = new StreamWriter("Assets/Musor/Buy/Jump.txt");
        Jump.WriteLine("false");
        Jump.Close();

        StreamWriter Tie = new StreamWriter("Assets/Musor/Buy/Tie.txt");
        Tie.WriteLine("false");
        Tie.Close();

        StreamWriter saving = new StreamWriter("Assets/Musor/Save.txt");
        saving.WriteLine("785 0 -860");
        saving.Close();
    }
}
