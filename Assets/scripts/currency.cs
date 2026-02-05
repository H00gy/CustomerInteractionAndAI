using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public static float currencyAmount;
    public TMP_Text currencyText;
    public float tempCurrentAmount;
    gameOver gameEnd;
    private void Awake()
    {
        // if there are more scenes, an if statement here for the first scene only
        currencyAmount = 100f;
        
        currencyText.text = currencyAmount.ToString();

        gameEnd = GameObject.FindWithTag("gameOver").GetComponent<gameOver>(); // finds in scene
        if (gameEnd == null)
        {
            Debug.Log("couldn't find gameOver");
            return;
        }
    }
    public void SetCurrency(float amount)
    {
        currencyAmount = amount;
        if (currencyAmount <= 0)
        {

        }
        currencyText.text = currencyAmount.ToString("F2");
        
    }
    public float returnCurrencyAmount()
    {
        Debug.Log("returnCurrency method amount " + currencyAmount);
        return currencyAmount;
    }

}
