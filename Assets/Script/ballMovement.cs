using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    Vector2 firstClick;
    Vector2 secondClick;
    Vector2 firstAndSecond;

    float force;
    float degree;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            firstClick = new Vector2(mousePos.x, mousePos.y);
        }

        if(Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector2.zero;
            mousePos = Input.mousePosition;
            secondClick = new Vector2(mousePos.x, mousePos.y);
            firstAndSecond = new Vector2(firstClick.x - secondClick.x, firstClick.y - secondClick.y);
            degree = (Mathf.Atan2(firstAndSecond.y, firstAndSecond.x) * Mathf.Rad2Deg);

            force = Vector2.Distance(firstClick, secondClick * 100f);

            Vector3 direction = Quaternion.AngleAxis(degree, Vector3.forward) * Vector3.right;

            rb.AddForce(direction * force);
        }
    }
}
