using UnityEngine;

public class SpawnNewCustomer : MonoBehaviour
{
    public GameObject customerPrefab;
    public  bool customerPresent;
    static int spawnCount = 0;
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
        spawnCount++;
        newCustomer.name = $"Customer_{spawnCount}";
        Debug.Log("customer is " + newCustomer.name);
        return newCustomer;
    }

}
