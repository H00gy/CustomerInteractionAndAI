using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public static float currencyAmount;
    public TMP_Text currencyText;
    private void Awake()
    {
        // if there are more scenes, an if statement here for the first scene only
        currencyAmount = 100f;
        currencyText.text = currencyAmount.ToString();
    }
    private void Update()
    {
        
    }
    public float returnCurrencyAmount()
    {
        //Debug.Log("returnCurrency method amount " + currencyAmount);
        return currencyAmount;
    }
}
