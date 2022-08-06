using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemie : Enemie
{ 
    [SerializeField] private Collider2D EagleColl;
    public Transform uppoint, downpoint;
    public int speed;
    //public Collider2D coll;
    //public GameObject dialogueBox;

    private float upy, downy;
    private bool isUP = true;
    [SerializeField]public bool canFly = false;
    private Rigidbody2D rb;

    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        upy = uppoint.position.y;
        downy = downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    void Update()
    {
        if (canFly == true)
        {
            EagleColl.isTrigger = false;
        }
        Move();
    }

    private void Move()
    {
         if(canFly)
         {
            if (isUP)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                if (transform.position.y > upy)
                {
                    isUP = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                if (transform.position.y < downy)
                {
                    isUP = true;
                }
            }
         }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            canFly = true;
            
        }
    }
    
}
