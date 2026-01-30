using UnityEngine;

public class customerTriggers : MonoBehaviour
{
    customer customerAI;
    currency money;
    float transaction;
    SpawnNewCustomer customerSpawner;
    
    private void Start()
    {
        customerAI = GetComponent<customer>();
        customerSpawner = GameObject.FindWithTag("gameManager").GetComponent<SpawnNewCustomer>();
        if (customerSpawner == null)
        {
            Debug.Log("couldn't find customer span");
            return;
        }
        money = GameObject.FindWithTag("currencyCount").GetComponent<currency>();
        if (money == null)
        {
            Debug.Log("couldn't find currency");
            return;
        }
        transaction = money.returnCurrencyAmount();
        Debug.Log("transaction value " + transaction);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(customerAI.isBuying && other.CompareTag("item"))
        {
            if (other.gameObject.GetComponentInChildren<SpriteRenderer>() != null && other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite == customerAI.currentShape) // checks if sr exists and then compares want and obj
            {
                // customer leaving
                Debug.Log("Thank you!");
                Destroy(other.gameObject);
                customerAI.playLeaveAnimation(this.gameObject);
                Destroy(this.gameObject);

                // money change
                transaction += other.GetComponent<itemPriceStorage>().price;// adds price
                money.currencyText.text = transaction.ToString("F2"); // currency count txt, ToString("F2") limits decimals
                
                
               
                customerSpawner.customerPresent = false; // safeguard 
                // currency change will occur here, possibly also destroy npc
            }
            else if (other.gameObject.GetComponentInChildren<SpriteRenderer>() == null)
            {
                Debug.Log("item sr not found");
            }
            else if(other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite != customerAI.currentShape)
            {
                Debug.Log("I don't want that >:(");
                Destroy(this.gameObject);
            }
        }
    }
}
