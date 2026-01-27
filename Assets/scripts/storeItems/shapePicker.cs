using UnityEngine;

public class shapePicker : MonoBehaviour
{
    // this script is a simple example of a wider procedural generation system
    public SpriteRenderer sr;
    public Sprite[] shapes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();   
    }

    public void pickRandomShape()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sr.sprite = shapes[Random.Range(0, shapes.Length)];
        }
    }
}
