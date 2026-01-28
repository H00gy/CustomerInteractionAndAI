using UnityEngine;

public class customerTriggers : MonoBehaviour
{
    customer customerAI;
    currency money;
    float transaction;
    
    private void Start()
    {
        customerAI = GetComponent<customer>();
        money = GameObject.FindWithTag("currencyCount").GetComponent<currency>();
        if (money == null)
        {
            Debug.Log("couldn't find currency");
            return;
        }
        transaction = money.returnCurrencyAmount();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(customerAI.isBuying && other.CompareTag("item"))
        {
            if (other.gameObject.GetComponentInChildren<SpriteRenderer>() != null && other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite == customerAI.buyingGroup().want) // checks if sr exists and then compares want and obj
            {
                Debug.Log("Thank you!");
                Destroy(other.gameObject);
                customerAI.playLeaveAnimation();
                
                transaction += other.GetComponent<itemPriceStorage>().price;// adds price
                //Debug.Log("the transaction value is " + transaction);
                money.currencyText.text = transaction.ToString(); // currency count txt
                
                Destroy(this.gameObject);
                customerAI.customerPresent = false;
                // currency change will occur here, possibly also destroy npc
            }
            else if (other.gameObject.GetComponentInChildren<SpriteRenderer>() == null)
            {
                Debug.Log("item sr not found");
            }
            else if(other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite != customerAI.buyingGroup().want)
            {
                Debug.Log("I don't want that >:(");
                Destroy(this.gameObject);
            }
        }
    }
}
