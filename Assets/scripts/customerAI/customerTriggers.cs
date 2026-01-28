using UnityEngine;

public class customerTriggers : MonoBehaviour
{
    customer customerAI;
    private void Start()
    {
        customerAI = GetComponent<customer>();
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
                Destroy(this.gameObject);
                customerAI.customerPresent = false;
                // currency change will occur here, possibly also destroy npc
            }
            else if (other.gameObject.GetComponentInChildren<SpriteRenderer>() == null)
            {
                Debug.Log("item sr not found");
            }
            else
            {
                Debug.Log("I don't want that >:(");
                Destroy(this.gameObject);
            }
        }
    }
}
