using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject itemPrefab;
    int spawnCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            spawnItem();
        }
    }
    void spawnItem()
    {
        GameObject spawnedItem = Instantiate(itemPrefab);
        spawnCount++;
        Debug.Log("spawned " + spawnedItem.name + " " + spawnCount);
        
    }
}
