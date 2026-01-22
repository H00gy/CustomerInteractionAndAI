using UnityEngine;

public class shapePicker : MonoBehaviour
{
    // this script is a simple example of a wider procedural generation system
    SpriteRenderer sr;
    public Sprite[] shapes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();   
    }

    void pickRandomShape()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sr.sprite = shapes[Random.Range(0, shapes.Length)];
        }
    }
}
