using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class reputationMeter : MonoBehaviour
{
    Slider reputation;
    public static float repValue = 0.75f;
    public float bargainModifier;
    gameOver gameOverObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reputation= GetComponent<Slider>();
        gameOverObj = GetComponent<gameOver>();
        reputation.value = repValue;
    }

    // Update is called once per frame
    void Update()
    {
        reputation.value = repValue;
        if (repValue <= 0)
        {
            gameOverObj.gameOverEnd();
        }
        

        // for debugging
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("the current rep value is " + repValue);
        }
        */

    }

    
}
