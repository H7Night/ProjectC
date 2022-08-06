using UnityEngine;
using UnityEngine.SceneManagement;
public class ToTwo1 : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            SceneManager.LoadScene("Two 1");
    }
}
