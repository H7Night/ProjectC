using UnityEngine;
using UnityEngine.SceneManagement;

public class ToOne : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            SceneManager.LoadScene("One");
    }
}
