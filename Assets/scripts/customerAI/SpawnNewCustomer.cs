using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnNewCustomer : MonoBehaviour
{
    public GameObject customerPrefab;
    public  bool customerPresent;
    static int spawnCount = 0;
    private void Awake()
    {

        StartCoroutine(SpawnLoop());

    }
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (!customerPresent)
            {
                yield return new WaitForSeconds(2);
                spawnCustomer();
            }

            yield return null; // wait one frame
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
