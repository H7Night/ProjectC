using UnityEngine;

public class Enemie : MonoBehaviour
{
    protected Animator anim;
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
    public void JumpOn()
    {
        anim.SetTrigger("dying");
    }

}
