using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer am;
    public void GameVolume(float sliderValue)
    {
        am.SetFloat("GameVolume", sliderValue);
    }
}
