using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    static public int count = 0;
    public GameObject prefab;
    public int kolvo = 200;
    GameObject[] coins;
    void Start()
    {
        coins = new GameObject[kolvo];
        for (int i = 0; i < kolvo; i++)
        {
            coins[i] = Instantiate(prefab);
            coins[i].transform.position = new Vector3(Random.Range(-1000f, 1000f), 20f, Random.Range(-1000f, 1000f));
        }
    }
}
