using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public Transform uppoint, downpoint;
    public int speed;

    private float upy, downy;
    private bool isUP = true;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        upy = uppoint.position.y;
        downy = downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
            if (isUP)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                if (transform.position.y >= upy)
                {
                    isUP = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                if (transform.position.y <= downy)
                {
                    isUP = true;
                }
            }
    }
}
