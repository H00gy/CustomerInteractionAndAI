using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currency : MonoBehaviour
{
    public static float currencyAmount;
    public TMP_Text currencyText;
    private void Start()
    {
        currencyAmount = 100f;
    }
    private void Update()
    {
        currencyText.text = currencyAmount.ToString();
    }
}
