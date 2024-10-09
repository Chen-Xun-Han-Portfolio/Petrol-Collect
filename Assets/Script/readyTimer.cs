using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readyTimer : MonoBehaviour
{
    public float curTime;
    [SerializeField] Text countdownReadyText;

    Coroutine coroutineRef;

    static public bool countDownCom;
    static public bool countPlay;
    static public bool startReady;

    // Start is called before the first frame update
    void Start()
    {
        countPlay = false;
        startReady = false;
        countDownCom = false;
        //countdownReadyText.text = "";
        //countdownReadyText.text = curTime.ToString();
        //coroutineRef = StartCoroutine(CountdownToStart());

        // Later to stop it
        //StopCoroutine(coroutineRef);

    }

    // Update is called once per frame
    void Update()
    {
        countdownReadyText.text = curTime.ToString("0");

        if (GameOptions.countPlay == true)
        {
            curTime -= 1 * Time.deltaTime;

            if (curTime <= 0)
            {
                curTime = 0;
                //startReady = true;
                ////countdownReadyText.text = "Go!";
                //curTime = 0;
                //countDownCom = true;
            }

            if (curTime == 0)
            {
                startReady = true;
                //countdownReadyText.text = "Go!";
                curTime = 0;
                countDownCom = true;
                GameOptions.countPlay = false;
                //StartCoroutine(CountdownToStart());
            }
        }
       
        //if (countPlay == true)
        //{
        //    Debug.Log("Stop");
        //    //StopCoroutine(CountdownToStart());
        //    StartCoroutine(CountdownToStart());
        //    //coroutineRef = StartCoroutine(CountdownToStart());
        //}

        if(startReady == true)
        {
            DragLine.startGame = true;
            CountdownTimer.startCount = true;
            //StopCoroutine(CountdownToStart());
            //Debug.Log("Stop");
        }
    }

    IEnumerator CountdownToStart()
    {
        while (curTime > 0)
        {
            countdownReadyText.text = curTime.ToString();
            yield return new WaitForSeconds(1f);
            curTime--;
        }

        countdownReadyText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countPlay = false;
        //DragLine.startGame = true;
        //CountdownTimer.startCount = true;
        startReady = true;
        //StopCoroutine(coroutineRef);
    }
}
