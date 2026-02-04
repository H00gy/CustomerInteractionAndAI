using UnityEngine;

public class paymentButton : MonoBehaviour
{
    //bool buttonPressed;
    customer customerAI;
    currency myMoney;
    void Start()
    {
        customerAI = GetComponentInParent<customer>();
        myMoney = GetComponentInParent<customer>().money;
        //Debug.Log("money for buttons = " + myMoney.returnCurrencyAmount());
        //buttonPressed = false;
    }
    public void buy()
    {
        myMoney.SetCurrency(myMoney.returnCurrencyAmount() - customerAI.sell());
        customerAI.playLeaveAnimation(this.transform.parent.gameObject);
    }
    public void reject()
    {
        customerAI.playLeaveAnimation(this.transform.parent.gameObject);
        if (customerAI.thisCustomersSoldItem!= null)
        {
            Destroy(customerAI.thisCustomersSoldItem);
        }
        
    }

    
}
