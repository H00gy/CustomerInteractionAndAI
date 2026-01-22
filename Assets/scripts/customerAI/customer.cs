using UnityEngine;

public class customer : MonoBehaviour
{
    
    bool customerPresent;
    private void Start()
    {
        newCustomer();
        


    }
    void newCustomer()
    {
        customerPresent= true;
        //bargainMultiplier = reputationMeter.repValue;
        playEnterAnimation();
        this.transform.position = new Vector2(0f, 0.81f); // temp since I don't have anim methods done
        
    }
    void playEnterAnimation() // will fill in later with animation scripts
    {

    }
    void playLeaveAnimation()
    {

    }
}
