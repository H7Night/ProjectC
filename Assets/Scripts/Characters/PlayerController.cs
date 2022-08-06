using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGround = false;

    //private bool isHurt = false;受傷檢測
    private int doubleJump; //二段跳功能

    public bool canMove = true;
    public float speed;
    public float Jumpforce;
    [SerializeField] public int cherry;
    //[SerializeField] public int gem;

    public LayerMask Ground;
    public Collider2D Coll;
    public Collider2D DisColl;
    public Transform CellingCheck, GroundCheck;
    public AudioSource JumpAudio;
    public AudioSource GetAudio;
    //public string scenePassword;
     private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()//fixupdate可以在不同电脑平滑展示效果
    {

        Move();
        Switchanim();
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }
    private void Update()
    {
        if (canMove)
        {
            Jump();
            Crouch();
        }

    }
    private void Move()
    {

        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if (canMove)
        {
            if (horizontalmove != 0)
            {
                rb.velocity = new Vector2(horizontalmove * speed * Time.fixedDeltaTime, rb.velocity.y);//deltaTime:*物理时钟百分比确保在不同设备不跳帧
                anim.SetFloat("running", Mathf.Abs(facedirection));
            }
            if (facedirection != 0)//调整面向
            {
                transform.localScale = new Vector3(facedirection, 1, 1);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


    }
    //趴下TODO
    private void Crouch()
    {
        if (!Physics2D.OverlapCircle(CellingCheck.position, 0.2f, Ground))
        {
            if (Input.GetButton("Crouch"))
            {
                anim.SetBool("crouching", true);
                DisColl.enabled = false;
            }
            else
            {
                anim.SetBool("crouching", false);
                DisColl.enabled = true;
            }
        }

    }
    //切换动画
    private void Switchanim()
    {
        anim.SetBool("idle", false);
        if (rb.velocity.y < 0.1f && !Coll.IsTouchingLayers(Ground))
        {
            anim.SetBool("falling", true);
        }
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (Coll.IsTouchingLayers(Ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
        #region 不需要。受傷動畫效果
        /*        
                else if (isHurt)
                {
                    anim.SetBool("hurting", true);
                    anim.SetFloat("running", 0);
                    if (Mathf.Abs(rb.velocity.x) < 0.1f)
                    {
                        anim.SetBool("hurting", false);
                        anim.SetBool("idle", true);
                        isHurt = false;
                    }
                }*/
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //收集
        if (collision.tag == "Collection")
        {
            GetAudio.Play();
            collision.GetComponent<Animator>().Play("Get");
        }
        //如果掉出地图返回起点
        if (collision.tag == "DeadLine")
        {
            Invoke("ReStart", 1f); //1s后調用ReStart
        }
    }
    public void ChrryCount()
    {
        cherry++;
    }
    // public void GemCount()
    // {
    //     gem++;
    // }
    #region 不需要。OnCollisionEnter2D,消滅敵人和受傷判斷。
    /*  
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Enemies")
         {
             //消灭敌人

             Enemie enemy = collision.gameObject.GetComponent<Enemie>();

             if (anim.GetBool("falling"))
             {
                 enemy.JumpOn();
                 rb.velocity = new Vector2(rb.velocity.x, Jumpforce * Time.deltaTime);
                 anim.SetBool("jumping", true);

             }


             //受伤
             if (transform.position.x < collision.gameObject.transform.position.x)
             {
                 rb.velocity = new Vector2(-1, rb.velocity.y);
                 //SoundManager.instance.HurtAudio();
                 isHurt = true;
             }
             else if (transform.position.x > collision.gameObject.transform.position.x)
             {
                 rb.velocity = new Vector2(1, rb.velocity.y);
                 //SoundManager.instance.HurtAudio();
                 isHurt = true;
             }
         }
     }
    */
    #endregion

    #region Jump
    // void Jump()
    // {
    //     if(isGround)
    //     {
    //         if(Input.GetButton("Jump"))
    //         {
    //             rb.velocity = Vector2.up * Jumpforce;
    //             anim.SetBool("jumping", true);
    //             JumpAudio.Play();
    //         }
    //     }
    //}

#region 二段跳功能
//二段跳功能
        void Jump()
        {
            if(isGround)
            {
                doubleJump = 1;
            }
            if (Input.GetButtonDown("Jump") && doubleJump>0)
            {
                rb.velocity = Vector2.up * Jumpforce;
                doubleJump--;
                JumpAudio.Play();
                anim.SetBool("jumping", true);
            }
            if(Input.GetButtonDown("Jump") && doubleJump == 0 && isGround)
            {
                rb.velocity = Vector2.up * Jumpforce;
                JumpAudio.Play();
                anim.SetBool("jumping", true);
            }
        }

        
        #endregion

    #endregion

    void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
