using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TMP_Text countRock;
    public TMP_Text countWooden;
    public TMP_Text countBlueH;
    public TMP_Text countRedH;

    public int CountRock;
    public int CountWooden;
    public int CountBlueH;
    public int CountRedH;
    private int Countrock;

    private void Start()
    {
        CountRock = 0;
        CountWooden = 0;
        CountBlueH = 0;
        CountRedH = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            CountRock += 1;
            countRock.text = CountRock.ToString();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Wooden"))
        {
            CountWooden += 1;
            countWooden.text = CountWooden.ToString();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BlueH"))
        {
            CountBlueH += 1;
            countBlueH.text = CountBlueH.ToString();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("RedH"))
        {
            CountRedH += 1;
            countRedH.text = CountRedH.ToString();
            Destroy(other.gameObject);
        }
    }
}