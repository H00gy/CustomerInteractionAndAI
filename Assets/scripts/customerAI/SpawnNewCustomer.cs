using UnityEngine;

public class SpawnNewCustomer : MonoBehaviour
{
    public GameObject customerPrefab;
    public  bool customerPresent;
    private void Awake()
    {
        spawnCustomer();
        
    }
    private void Update()
    {
        if (customerPresent == false)
        {
            spawnCustomer();
        }
    }
    public GameObject spawnCustomer()
    {
        GameObject newCustomer = Instantiate(customerPrefab);
        Debug.Log("spawned Customer");
        customerPresent= true;
        newCustomer.transform.position= new Vector2(0f, 0.81f);
        return newCustomer;
    }

}
