using UnityEngine;

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
    void spawnItem()
    {
        GameObject spawnedItem = Instantiate(itemPrefab);
        spawnCount++;
        spawnedItem.name = $"item_{spawnCount}";
        
        
        ItemInstance instance = spawnedItem.GetComponent<ItemInstance>();
        if(instance == null)
        {
            Debug.LogWarning("Spawned item missing itemInstance component!");
            return;
        }
        instance.Generate(); // calls its own generation
        lastInstance= spawnedItem;
        checker.checkAuthenticity(instance);
        spawnedItem.GetComponent<itemPriceStorage>().price = checker.price;


    }
}
