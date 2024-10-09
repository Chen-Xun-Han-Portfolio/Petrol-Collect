using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOptions : MonoBehaviour
{
    //public Button yes;
    //public Button no;

    public GameObject GamePanel;
    public GameObject HowPanel;
    public GameObject readyPanel;

    public GameObject playerBall;

    static public bool backMain;
    static public bool gameReady;

    public float curTime = 0;
    public float readyTime = 5;

    static public bool countPlay;
    static public bool readyCount;

    //[SerializeField] Text countdownReadyText;

    public Animator transition;
    public float transitionTime = 1;

    public float reset = 0;

    void Awake()
    {
        //Time.timeScale = 1f;
        //GamePanel.SetActive(false);
        //HowPanel.SetActive(true);
        //readyPanel.SetActive(false);
        //SceneManager.LoadScene("GameScene");
    }

    void Start()
    {
        //Time.timeScale = 1f;
        curTime = readyTime;
        countPlay = false;
        backMain = false;
        readyCount = false;

        readyTimer.startReady = false;
        readyTimer.countDownCom = false;
        readyTimer.countPlay = false;
        //StartCoroutine(CountdownToStart());
    }

    private void Update()
    {
        //countdownReadyText.text = curTime.ToString("0");

        if (!HowPanel)
        {
            Debug.Log("Game");
            GamePanel.SetActive(false);
            readyPanel.SetActive(false);
            HowPanel.SetActive(true);
        }

        if (reset > 0)
        {
            reset -= 1 * Time.deltaTime;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (reset == 0)
        {
            reset = 0;
        }

        if (countPlay == true)
        {
            readyCount = true;
            GamePanel.SetActive(true);
            readyPanel.SetActive(true);
            HowPanel.SetActive(false);
            //DragLine.startGame = false;
        }

        if (readyTimer.startReady == true)
        {
            countPlay = false;
            readyPlay();
            //Debug.Log("Go!");
            //DragLine.startGame = false;
        }

        //if (startPlay == true)
        //{
        //    readyPlay();
        //    //curTime -= 1 * Time.deltaTime;
        //    DragLine.startGame = false;
        //    //StartCoroutine(CountdownToStart());
        //}

        //if (curTime <= 0)
        //{
        //    //curTime = 0;
        //    GamePanel.SetActive(true);
        //    readyPanel.SetActive(false);
        //    DragLine.startGame = true;
        //    CountdownTimer.startCount = true;
        //}

        if(readyTimer.countDownCom == true)
        {
            GamePanel.SetActive(true);
            readyPanel.SetActive(false);
            DragLine.startGame = true;
            CountdownTimer.startCount = true;
            //Debug.Log("Start");
        }

        //if (DragLine.isLose == true)
        //{
        //    Time.timeScale = 1f;
        //    GamePanel.SetActive(false);
        //    HowPanel.SetActive(true);
        //    //readyPanel.SetActive(false);
        //    // playerBall.SetActive(false);
        //}

        //if (DragLine.isWin == true)
        //{
        //    GamePanel.SetActive(true);
        //    HowPanel.SetActive(false);
        //    //readyPanel.SetActive(false);
        //    // playerBall.SetActive(false);
        //}
    }

    public void optionsMenu()
    {
        Time.timeScale = 0f;
    }

    public void backToMain()
    {
        //Time.timeScale = 1f;
        //StartCoroutine(MainLevel());
        //readyPanel.SetActive(false);
        //GamePanel.SetActive(false);
        //HowPanel.SetActive(true);
        SceneManager.LoadScene("MainMenuScene");
        //backMain = true;
    }

    public void backOptions()
    {
        Time.timeScale = 1f;
    }

    public void readyPlay()
    {
        readyPanel.SetActive(false);
        GamePanel.SetActive(true);
        HowPanel.SetActive(false);
        DragLine.startGame = false;
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator MainLevel()
    {
        transition.SetBool("Fade", true);
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("MainMenuScene");
    }

    //IEnumerator CountdownToStart()
    //{
    //    while (curTime > 0)
    //    {
    //        countdownReadyText.text = curTime.ToString();
    //        yield return new WaitForSeconds(1f);
    //        curTime--;
    //    }

    //    countdownReadyText.text = "GO!";
    //    yield return new WaitForSeconds(1f);
    //    DragLine.startGame = true;
    //    CountdownTimer.startCount = true;
    //}
}
