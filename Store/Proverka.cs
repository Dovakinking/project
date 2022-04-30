using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class Proverka : MonoBehaviour
{
    /*void Update()
    {
        var preset = AssetDatabase.LoadAssetAtPath<Preset>(SelectionSpritePreset);
        var spritePath = AssetDatabase.GetAssetPath(_properties.SelectionSprite.objectreferenceValue);
        var spriteImporter = AssetImporter.GetAtPath(spritePath);
        preset.applyTo(spriteImporter);
    }*/
    public string x;
    public string y;
    public string z;


    void Start()
    {

        StreamReader GoldenTie = new StreamReader("Assets/Musor/Buy/GoldenTie.txt");
        x = GoldenTie.ReadLine();
        GoldenTie.Close();

        StreamReader Jump = new StreamReader("Assets/Musor/Buy/Jump.txt");
        y = Jump.ReadLine();
        Jump.Close();

        StreamReader Tie = new StreamReader("Assets/Musor/Buy/Tie.txt");
        z = Tie.ReadLine();
        Tie.Close();

    }
    void Update()
    {
        /*if ((Convert.ToBoolean(x) == true) && (Convert.ToBoolean(y) == true))
        {
            _11.applyTo(xxx);
        }
        else if ((Convert.ToBoolean(x) == true) && (Convert.ToBoolean(y) == false))
        {
            _10.applyTo(xxx);
        }
        else if ((Convert.ToBoolean(y) == false) && (Convert.ToBoolean(y) == true))
        {
            _01.applyTo(xxx);
        }
        else
        {
            Default.applyTo(xxx);
        }*/
       
    }
}
