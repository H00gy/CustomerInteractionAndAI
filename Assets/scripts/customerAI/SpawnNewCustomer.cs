using UnityEngine;

public class SpawnNewCustomer : MonoBehaviour
{
    public GameObject customerPrefab;
    public GameObject spawnCustomer()
    {
        GameObject newCustomer = Instantiate(customerPrefab);
        Debug.Log("spawned Customer");
        return newCustomer;
    }
}
