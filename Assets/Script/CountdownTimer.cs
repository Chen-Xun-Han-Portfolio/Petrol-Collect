using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 0;
    public float startingTime = 10;

    static public bool startCount;
    static public bool timeUp;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        startCount = false;
        timeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = currentTime.ToString("0");
        //currentTime -= 1 * Time.deltaTime;

        if (startCount == true)
        {
            currentTime -= 1 * Time.deltaTime;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            timeUp = true;
            DragLine.isLose = true;
        }

        if (currentTime <= 10)
        {
            countdownText.color = Color.red;
        }

        
    }
}
