using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    private string x;
    private string z;

    public GameObject warning;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject prefab;
    [SerializeField] private AudioSource Money;
    private void Start()
    {
        StreamReader GoldenTie = new StreamReader("Assets/Musor/Buy/GoldenTie.txt");
        x = GoldenTie.ReadLine();
        GoldenTie.Close();

        StreamReader Tie = new StreamReader("Assets/Musor/Buy/Tie.txt");
        z = Tie.ReadLine();
        Tie.Close();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Money.Play();
            Stand(other.transform.position.x, (float)(other.transform.position.y-0.1), other.transform.position.z);
            Collector.count += Random.Range(1, 20);
            Destroy(other.gameObject);
            SaveGame(); 
        }
        else if (other.gameObject.CompareTag("Finish") && (x == "True" || z == "True"))
        {
            SceneManager.LoadScene("EndGame");
        }
        else if (other.gameObject.CompareTag("Finish") && (x == "false" && z == "false"))
        {
            warning.SetActive(true);
            a1.SetActive(false);
            a2.SetActive(false);
            a3.SetActive(false);
            a4.SetActive(false);
        }
    }
    public void Stand(float x, float y, float z)
    {
        Instantiate(prefab).transform.position = new Vector3(x, y, z);
    }
    public void SaveGame()
    {
        StreamWriter writer = new StreamWriter("Assets/Musor/Data.txt");
        writer.WriteLine(Collector.count);
        writer.Close(); 
    }

}
