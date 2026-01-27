using UnityEngine;

public class itemPriceStorage : MonoBehaviour
{
    public float price;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("this objects price is " + getPrice());
        }
    }
    public float getPrice()
    {
        return price;
    }
}
