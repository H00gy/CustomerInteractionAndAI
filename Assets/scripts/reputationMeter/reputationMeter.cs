using UnityEngine;
using UnityEngine.UI;

public class reputationMeter : MonoBehaviour
{
    Slider reputation;
    public static float repValue = 0.75f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reputation= GetComponent<Slider>();
        reputation.value = repValue;
    }

    // Update is called once per frame
    void Update()
    {
        reputation.value = repValue;
    }
}
