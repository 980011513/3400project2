using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TMP_Text resultText;
    public Slider oxygen;
    public Slider fuel;
    public float totalOxygenTime = 60f;
    public PlayerMovement playerMovement;

    float oxygenRemaining;
    float maxFuel;
    float fuelRemaining;


    void Start()
    {
        if (resultText)
        {
            resultText.gameObject.SetActive(false);
        }

        oxygenRemaining = totalOxygenTime;
        if (oxygen)
        {
            oxygen.maxValue = oxygenRemaining;
        }

        if (playerMovement)
        {
            maxFuel = playerMovement.jetpackMaxEnergy;
            fuel.maxValue = maxFuel;
        }
    }

    void Update()
    {
        if (playerMovement)
        {
            fuelRemaining = playerMovement.JetpackEnergy;
            fuel.value = fuelRemaining;
        }

        oxygenRemaining -= Time.deltaTime;

        if (oxygen)
        {
            oxygen.value = oxygenRemaining;
        }

        if (oxygenRemaining <= 0)
        {
            SetText("YOU LOSE");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetText("YOU WIN!");
        }
    }

    void SetText(string text)
    {
        if (resultText)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = text;
        }
    }
}
