using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Transactions;

public class customer : MonoBehaviour
{
    public BoxCollider2D bc;
    public bool customerPresent;
    public bool isBuying; 
    public float hagglePercent;
    public customerWantsGroup[] wants;
    public TMP_Text dialogue;
    public Sprite currentShape; // sets the want shape for this specific customer
    SpawnNewCustomer customerSpawner;
    spawner itemSpawner;
    currency money;
    float transaction;
    public float lowRepPercentage = 1.3f;

    // temp animation variables (this is all placeholder until I make animations for the actual game)
    public float speed = 5f;
    public Vector2 outScenePos = new Vector2(-100f, 0);
    public Vector2 inScenePos = new Vector2(0, 0);
    
    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
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
        StartCoroutine(firstCustomer());    
        


    }
    IEnumerator firstCustomer()
    {
        yield return null; // wait one frame
        newCustomer();
    }
    void newCustomer()
    {
        Debug.Log("called this");
        //customerSpawner.spawnCustomer();
        // sets placement
        customerPresent = true;
        //bargainMultiplier = reputationMeter.repValue;

        //this.transform.position = new Vector2(0f, 0.81f); // temp since I don't have anim methods done //changed from this.
        //buy(); //temp for testing
        sell();
        /*
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
        */
        
        
    }
    
    public void playLeaveAnimation(GameObject prefab)
    {
        
        customerSpawner.customerPresent = false;
        prefab.transform.position = outScenePos;
        
        /*
        Debug.Log("called leave anim");
        Debug.Log("customer position prior to leave is " + prefab.transform.position);
        float awayMovt = speed * Time.deltaTime;
        prefab.transform.position = Vector2.MoveTowards(transform.position,outScenePos,awayMovt);
        Debug.Log("customer position after leave is " + prefab.transform.position);
        //prefab.transform.position = new Vector2(-100f, 0);
        */
        
        
        
        

    }
    void buy()
    {
        isBuying = true;
        currentShape = buyingGroup().want; // makes sure it's currently stored
        
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

    void sell()
    {
        
        StartCoroutine(sellAfterItemReady());
        
    }
    IEnumerator sellAfterItemReady()
    {
        yield return null; // wait one frame
        Debug.Log("sell is called");
        GameObject soldItem = itemSpawner.spawnItem();
        float reputationMulitplier = lowRepPercentage - reputationMeter.repValue; //percentage to haggle
        float wantedPrice = soldItem.GetComponent<itemPriceStorage>().price * reputationMulitplier;
        dialogue.text = "I want $" + wantedPrice;
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
