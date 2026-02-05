using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Transactions;

public class customer : MonoBehaviour
{
    // bool conditions
    public bool customerPresent;
    public bool isBuying;

    // spawners
    SpawnNewCustomer customerSpawner;
    spawner itemSpawner;
    // customer wants
    public customerWantsGroup[] wants;
    public TMP_Text dialogue;
    public Sprite currentShape; // sets the want shape for this specific customer

    // related to currency/reputation
    public currency money;
    float transaction;
    public float lowRepPercentage = 1.3f;
    public float hagglePercent;

    // buttons
    paymentButton buttonsScript;
    public GameObject buttons;

    // misc
    public BoxCollider2D bc;
    public GameObject thisCustomersSoldItem;

    // temp animation position variables (this is all placeholder until I make animations for the actual game)
    public Vector2 outScenePos = new Vector2(-100f, 0);
    public Vector2 inScenePos = new Vector2(0, 0);

   
    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        buttonsScript = GetComponentInChildren<paymentButton>();
        buttons.SetActive(false);
        customerSpawner = GameObject.FindWithTag("gameManager").GetComponent<SpawnNewCustomer>();
        if (customerSpawner == null)
        {
            Debug.Log("couldn't find customer spawner");
            return;
        }
        itemSpawner = GameObject.FindWithTag("gameManager").GetComponent<spawner>();
        if (itemSpawner == null)
        {
            Debug.Log("couldn't find item spawner");
            return;
        }
        money = GameObject.FindWithTag("currencyCount").GetComponent<currency>();
        if (money == null)
        {
            Debug.Log("couldn't find currency");
            return;
        }
        
        transaction = money.returnCurrencyAmount();
        StartCoroutine(firstCustomer()); // safeguard
        


    }
    IEnumerator firstCustomer()
    {
        yield return null; // wait one frame
        newCustomer();
    }
    void newCustomer()
    {
        // sets placement
        customerPresent = true;
        
        // calls buying or selling
        bool buyOrSell = Random.value > 0.5f; // coin toss
        if (buyOrSell)
        {
            Debug.Log("buy");
            buy();
        }
        else
        {
            Debug.Log("sell");
            sell();
        }      
        
    }
    
    public void playLeaveAnimation(GameObject prefab)
    {
        
        customerSpawner.customerPresent = false;
        prefab.transform.position = outScenePos;
        Destroy(this.gameObject);

    }
    void buy()
    {
        isBuying = true;
        currentShape = buyingGroup().want; // makes sure it's currently stored

        if (GameObject.FindWithTag("item") == null) // so buy() doesn't get stuck if the player has no inventory
        {
            playLeaveAnimation(this.gameObject);
            reputationMeter.repValue -= .01f;
            return;
        }
        
        if (isBuying == false)
        {
            return;
        }

    }
    public customerWantsGroup buyingGroup()
    {
        // cycles through dialogue options 
        int index = Random.Range(0, wants.Length);
        customerWantsGroup group = wants[index];
        dialogue.text = wants[index].speech;
        Debug.Log("want sprite " + wants[index].want.name);
        return group;
    }

    public void sell()
    {
        GameObject soldItem = itemSpawner.spawnItem();
        thisCustomersSoldItem= soldItem;
        soldItemPrice(thisCustomersSoldItem);
        buttons.SetActive(true);

    }
    public float soldItemPrice(GameObject thisItem)
    {
        float reputationMulitplier = lowRepPercentage - reputationMeter.repValue; //percentage to haggle
        float wantedPrice = thisItem.GetComponent<itemPriceStorage>().price * reputationMulitplier;
        dialogue.text = "I want $" + wantedPrice.ToString("F2");
        return wantedPrice;
    }

    
    /* 
    void haggleChance() not going to use haggle chance rn, but its a good idea for later
    {

       hagglePercent = 1 - reputationMeter.repValue; // randomizes if they will haggle
       float randomValue = Random.value;
       
       if (randomValue < hagglePercent) // negative haggle
       {
            Debug.Log("haggle engaged");
            GameObject soldItem = itemSpawner.spawnItem();
            // the wanted price increases based on the value 
            float wantedPrice = (soldItem.GetComponent<itemPriceStorage>().price + (soldItem.GetComponent<itemPriceStorage>().price * hagglePercent)); 

       }
       else
       {
            Debug.Log("no haggle");
       }

    }
    */

}
