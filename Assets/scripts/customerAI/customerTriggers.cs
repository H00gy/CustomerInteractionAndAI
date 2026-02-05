using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class customerTriggers : MonoBehaviour
{
    customer customerAI;
    currency money;
    float transaction;
    SpawnNewCustomer customerSpawner;
    
    private void Start()
    {
        customerAI = GetComponent<customer>();
        customerSpawner = GameObject.FindWithTag("gameManager").GetComponent<SpawnNewCustomer>(); // finds in scene
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
        Debug.Log("Start transaction value " + transaction);
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (customerAI.isBuying && other.CompareTag("item"))
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
                Debug.Log("bought transaction value is " + transaction);
                money.SetCurrency(transaction);
                Debug.Log("get current amount value is " + money.returnCurrencyAmount());
                

                // rep change
                reputationMeter.repValue += 0.005f;

                // safeguard 
                customerSpawner.customerPresent = false; 
            }
            else if (other.gameObject.GetComponentInChildren<SpriteRenderer>() == null)
            {
                Debug.Log("item sr not found");
            }
            else if(other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite != customerAI.currentShape)
            {
                Debug.Log("I don't want that >:(");
                customerAI.playLeaveAnimation(this.gameObject);
                
                Destroy(this.gameObject);
            }
        }
    }
    
}

