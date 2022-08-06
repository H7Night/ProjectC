using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnemie : Enemie
{

    public bool canMove;
    public LayerMask ground;
    public Collider2D boxcoll;
    public GameObject cherryUI;

    private Rigidbody2D rb;
    private Collider2D coll;

    public float speed, jumpforce;
    public Transform leftpoint, rightpoint;
    private bool Faceleft = true;
    private float leftx, rightx;
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
        // leftx = leftpoint.position.x;
        // rightx = rightpoint.position.x;
        // Destroy(leftpoint.gameObject);
        // Destroy(rightpoint.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && cherryUI.activeInHierarchy)
        {
            if(PlayerController.instance.cherry > 0)
            {
                PlayerController.instance.cherry--;
                boxcoll.isTrigger = true;
                cherryUI.SetActive(false);
            }

        }
        
        //DialogSystem.instance.ShowDialogue(talkable.congratsLines, talkable.hasName);
    }
    // private void Update()
    // {
    //     //SwitchAnim();
    // }
    #region MOVE & JUMP ANIMATION
    private void Move()
    {
        if (canMove)
        {
            if (Faceleft)
            {
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-speed, jumpforce);
                    anim.SetBool("jumping", true);
                }
                if (transform.position.x < leftx)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    Faceleft = false;
                }
            }
            else
            {
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(speed, jumpforce);
                    anim.SetBool("jumping", true);
                }

                if (transform.position.x > rightx)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    Faceleft = true;
                }
            }
        }

        // }
        // private void SwitchAnim()
        // {
        //     if(anim.GetBool("jumping"))
        //     {
        //         if(rb.velocity.y < 0.1f)
        //         {
        //             anim.SetBool("jumping", false);
        //             anim.SetBool("falling", true);
        //         }
        //     }
        //     if(coll.IsTouchingLayers(ground) && anim.GetBool("falling"))
        //     {
        //         anim.SetBool("falling", false);
        //     }
        // }
        #endregion
    }
}

