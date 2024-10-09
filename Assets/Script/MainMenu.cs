using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    //public Animator transition;
    public Image imageMaterial;

    public float dirX;
    public float dirY;
    public float transitionTime = 1;

    public bool start;

    void Start()
    {
        transform.DOLocalMove(new Vector2(dirX, dirY), transitionTime).SetEase(Ease.InOutSine);
        imageMaterial.DOFade(0, 0).SetDelay(transitionTime);

        start = false;
    }

    public void Update()
    {
        //if(Input.GetKeyDown("space"))
        //{
        //    playStart();
        //}
       

        if (GameOptions.backMain == true)
        {
            //StartCoroutine(MainLevel());
            Debug.Log("Main");
        }

        if(start == true)
        {
            imageMaterial.DOFade(1, 0);
            transform.DOLocalMove(new Vector2(0, 0), transitionTime).SetEase(Ease.InOutSine);
            Debug.Log("start");
        }
    }

    public void playStart()
    {
        SceneManager.LoadScene("GameScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //start = true;
        //StartCoroutine(LoadLevel());
    }

    public void reset()
    {
        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //StartCoroutine(sLoadLevel());
    }

    public void backToMain()
    {
        Time.timeScale = 1f;
        //StartCoroutine(MainLevel()); 
    }

    IEnumerator LoadLevel()
    {
        //imageMaterial.DOFade(1, 0);
        transform.DOLocalMove(new Vector2(0, 10000), transitionTime).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //zzSceneManager.LoadScene("GameScene");
    }

    IEnumerator MainLevel()
    {
        imageMaterial.DOFade(1, 0);
        transform.DOLocalMove(new Vector2(0, 0), transitionTime).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainScene");
    }
}
