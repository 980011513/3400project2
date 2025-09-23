using UnityEngine;
using TMPro;

public class levelComplete : MonoBehaviour
{
    public TMP_Text winText;

    void Start()
    {
        if (winText)
        {
            winText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (winText)
            {
                winText.gameObject.SetActive(true);
                winText.text = "YOU WIN!";
            }
        }
    }
}
