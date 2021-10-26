using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timeValue = 300;
    public Text timerLabel;

    private void DisplayTimer()
    {
        int roungTimeValue = (int)timeValue;

        timerLabel.text = roungTimeValue.ToString().PadLeft(3, '0');
    }

    // Start is called before the first frame update
    void Start()
    {
        timerLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue >= 0) {
            timeValue -= Time.deltaTime;
            DisplayTimer();
        }
    }
}
