using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class customer : MonoBehaviour
{
    
    public bool customerPresent;
    public bool isBuying; 
    public float hagglePercent;
    public customerWantsGroup[] wants;
    public TMP_Text dialogue;
    public Sprite currentShape; // sets the want shape for this specific customer
    SpawnNewCustomer customerSpawner;
    
    private void Start()
    {
        customerSpawner = GameObject.FindWithTag("currencyCount").GetComponent<SpawnNewCustomer>();
        if (customerSpawner == null)
        {
            Debug.Log("couldn't find customer spawner");
            return;
        }
        newCustomer();
        


    }
    void newCustomer()
    {
        customerSpawner.spawnCustomer();
        //transform.gameObject = customerSpawner;
        // sets placement
        customerPresent = true;
        //bargainMultiplier = reputationMeter.repValue;

        this.transform.position = new Vector2(0f, 0.81f); // temp since I don't have anim methods done //changed from this.
        
        buy(); // temp for testing
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
    public void playEnterAnimation(GameObject prefab) // will fill in later with animation scripts
    {

    }
    public void playLeaveAnimation(GameObject prefab)
    {
        customerPresent= false;
        Debug.Log("customerPresent? " + customerPresent);
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
        haggleChance();
    }
    void haggleChance()
    {
       hagglePercent = 1 - reputationMeter.repValue;
       float randomValue = Random.value;
       
       if (randomValue < hagglePercent)
       {
            //Debug.Log("haggle engaged");
       }
       else
       {
            //Debug.Log("no haggle");
       }

    }
   
    

    

}
