using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DragLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;

    public float power;
    public float checkForce = 0;

    public Material material;
    public float startWidth = 0.2f;
    public float endWidth = 0f;
    public Color startColour = Color.white;
    public Color endColour = Color.clear;

    public bool shot;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

    public GameObject winPanel;
    public GameObject losePanel;

    static public bool isWin;
    static public bool isLose;
    static public bool startGame;

    public int points;
    [SerializeField] Text totalPoints;
    [SerializeField] Text totalPointsWin;
    [SerializeField] Text totalPointsLose;

    RectTransform rectT;

    public AudioSource source;
    public AudioClip pointSound;
    public AudioClip hole;
    public AudioClip bounce;

    public Image imageBall;

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        isLose = false;
        startGame = false;

        rb = GetComponent<Rigidbody2D>();
        rectT = GetComponent<RectTransform>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
        lineRenderer.material = material;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.startColor = startColour;
        lineRenderer.endColor = endColour;
        lineRenderer.numCapVertices = 20;
    }

    // Update is called once per frame
    void Update()
    {
        totalPoints.text = points.ToString("0");
        totalPointsWin.text = points.ToString("0");
        totalPointsLose.text = points.ToString("0");

        if (Input.GetMouseButtonDown(0) && isWin == false && isLose == false && startGame == true)
        {
            Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, startPos);
            lineRenderer.enabled = true;
        }

        if (Input.GetMouseButton(0) && isWin == false && isLose == false && startGame == true)
        {
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(1, endPos);
        }

        if (Input.GetMouseButtonUp(0) && isWin == false && isLose == false && startGame == true)
        {
            lineRenderer.enabled = false;

            Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
            //checkForce = Vector3.Distance(lineRenderer.GetPosition(0) / 2, lineRenderer.GetPosition(1) / 2);
            //checkForce = rb.velocity.magnitude;
            //checkForce -= 1 * Time.deltaTime;
            rb.AddForce(inputForce, ForceMode2D.Impulse);           
        }

        if (isLose == true)
        {
            losePanel.SetActive(true);
            lineRenderer.enabled = false;
            //isLose = false;
        }

        if(isWin == true)
        {
            lineRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GameReady")
        {
            GameOptions.countPlay = true; 
            Debug.Log("IN");
        }

        if (other.gameObject.tag == "Points" && isLose == false && isWin == false)
        {
            //coins.Play();
            Destroy(other.gameObject);
            points += 1;
            source.PlayOneShot(pointSound);
        }

        if (other.gameObject.tag == "Goal1")
        {
            source.PlayOneShot(hole);
            level1.SetActive(false);
            level2.SetActive(true);
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Goal2")
        {
            source.PlayOneShot(hole);
            level2.SetActive(false);
            level3.SetActive(true);
        }

        if (other.gameObject.tag == "Goal3")
        {
            source.PlayOneShot(hole);
            level3.SetActive(false);
            level4.SetActive(true);
        }

        if (other.gameObject.tag == "Goal4")
        {
            source.PlayOneShot(hole);
            level4.SetActive(false);
            level5.SetActive(true);
        }

        if (other.gameObject.tag == "Goal5" && isLose == false)
        {
            source.PlayOneShot(hole);
            imageBall.DOFade(0, 0);
            Destroy(rb);
            winPanel.SetActive(true);
            isWin = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            source.PlayOneShot(bounce);
        }
    }

    //IEnumerator Release()
    //{
    //    yield return new WaitForSeconds(5f);
    //}
}


