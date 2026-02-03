using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawner : MonoBehaviour
{
    public GameObject itemPrefab;
    static int spawnCount = 0;
    public GameObject lastInstance;
    public authenticityChecker checker;

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnItem();
        }
    }
    public GameObject spawnItem()
    {
        GameObject spawnedItem = Instantiate(itemPrefab);
        spawnCount++;
        spawnedItem.name = $"item_{spawnCount}";
        
        
        ItemInstance instance = spawnedItem.GetComponent<ItemInstance>();
        if(instance == null)
        {
            Debug.LogWarning("Spawned item missing itemInstance component!");
            return null;
        }
        instance.Generate(); // calls its own generation
        lastInstance= spawnedItem;
        checker.checkAuthenticity(instance);
        //StartCoroutine(checkerRun(instance));  
        spawnedItem.GetComponent<itemPriceStorage>().price = checker.price;
        return spawnedItem;


    }
    /*
    IEnumerator checkerRun(ItemInstance instance)
    {
        yield return null;
        checker.checkAuthenticity(instance);

    }
    IEnumerator returnPrice()
    {
        yield return null;
        checker.getPrice();
    }
    */
}
