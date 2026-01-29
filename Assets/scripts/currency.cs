using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public static float currencyAmount;
    public float currentCurrency;
    public TMP_Text currencyText;
    private void Start()
    {
        currencyAmount = 100f;
        currencyText.text = currencyAmount.ToString();
    }
    private void Update()
    {
        
    }
    public float returnCurrencyAmount()
    {
        // returnCurrencyAmount is returning zero, need to get it to return the Start() value
        Debug.Log("returnCurrency method amount " + currencyAmount);
        currentCurrency= currencyAmount;
        return currentCurrency;
    }
}
