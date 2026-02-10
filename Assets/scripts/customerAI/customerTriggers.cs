using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class customerTriggers : MonoBehaviour
{
    customer customerAI;
    currency money;
    float transaction;
    SpawnNewCustomer customerSpawner;
    int correctWantCount;
    
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
            for (int i = 0; i < other.transform.childCount; i++)
            {
                if (other.transform.GetChild(i).GetComponent<SpriteRenderer>() != null && other.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite?.name == customerAI.currentShape?.name) // checks if sr exists and then compares want and obj, 
                { // also ? to the left of the if statement is called null condition operator, it means "if thing to the left null, register as null and dont crash"
                    Debug.Log("Customer Want Success");

                    correctWantCount++;


                    // rep change
                    reputationMeter.repValue += 0.005f;


                }
                else if (other.transform.GetChild(i).GetComponent<SpriteRenderer>() == null)
                {
                    Debug.Log("Customer Want sr not found");
                    Debug.Log("item sr not found");
                }
            }

            if (correctWantCount > 0)
            {
                // customer leaving
                Debug.Log("Thank you!");
                // leave satisfied
                Destroy(other.gameObject);

                customerAI.playLeaveAnimation(this.gameObject);
                Destroy(this.gameObject);

                // money change
                transaction += other.GetComponent<itemPriceStorage>().price;// adds price
                Debug.Log("bought transaction value is " + transaction);
                money.SetCurrency(transaction);
                Debug.Log("get current amount value is " + money.returnCurrencyAmount());

                // safeguard 
                customerSpawner.customerPresent = false;
            }

            else if (correctWantCount <= 0)
            {
                Debug.Log("Customer Want fail");
                Debug.Log("I don't want that >:(");
                Debug.Log("want sprite name" + customerAI.currentShape.name);
                customerAI.playLeaveAnimation(this.gameObject);

                Destroy(this.gameObject);
            }
        }
    }
    
}

