using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public string tagToCount;
    public TMP_Text countText;
    private int count;

    private void Start()
    {
        count = 0;
        UpdateCountText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagToCount))
        {
            count += 1;
            UpdateCountText();
        }
    }

    private void UpdateCountText()
    {
        countText.text = count.ToString();
    }
}