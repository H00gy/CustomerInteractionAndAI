using UnityEngine;

public class resetPos : MonoBehaviour
{
    GameObject[] items;
    public void resetPositions()
    {
        items = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject item in items)
        {
            item.transform.position = new Vector2(Random.Range(-2.5f,2.5f),-1f);
        }
    }
   
}
