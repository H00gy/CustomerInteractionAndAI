using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class customer : MonoBehaviour
{
    
    bool customerPresent;
    public float hagglePercent;
    public customerWantsGroup[] wants;
    public TMP_Text dialogue; 
    
    private void Start()
    {
        newCustomer();
        


    }
    void newCustomer()
    {
        // sets placement
        customerPresent= true;
        //bargainMultiplier = reputationMeter.repValue;
        playEnterAnimation();
        this.transform.position = new Vector2(0f, 0.81f); // temp since I don't have anim methods done

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
    void playEnterAnimation() // will fill in later with animation scripts
    {

    }
    void playLeaveAnimation()
    {

    }
    void buy()
    {

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
            Debug.Log("haggle engaged");
       }
       else
       {
            Debug.Log("no haggle");
       }

    }
    
        
    
}
