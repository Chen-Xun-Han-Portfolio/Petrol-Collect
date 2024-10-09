using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragHow : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    RectTransform rectT;

    public Material material;
    public float startWidth = 0.2f;
    public float endWidth = 0f;
    public Color startColour = Color.white;
    public Color endColour = Color.clear;

    // Start is called before the first frame update
    void Start()
    {

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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, startPos);
            lineRenderer.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(1, endPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;

            Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
            //checkForce = Vector3.Distance(lineRenderer.GetPosition(0) / 2, lineRenderer.GetPosition(1) / 2);
            //checkForce = rb.velocity.magnitude;
            //checkForce -= 1 * Time.deltaTime;
            rb.AddForce(inputForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GameReady")
        {
            GameOptions.countPlay = true;
            Debug.Log("IN");
        }
    }
}