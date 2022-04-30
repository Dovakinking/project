using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject destroy;
    public float timeLeft = 3f;
    void Update()
    {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(destroy);
            }
    }
}
