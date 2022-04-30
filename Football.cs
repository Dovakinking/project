using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    public GameObject fireworks;
    [SerializeField] private AudioSource Goal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Goal.Play();
            boom(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            Collector.count += Random.Range(5, 10);
        }
    }
    public void boom(float x, float y, float z)
    {
        Instantiate(fireworks).transform.position = new Vector3(x, y, z);
    }
}
