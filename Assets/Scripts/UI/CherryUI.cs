using UnityEngine;

public class CherryUI : MonoBehaviour
{
    public GameObject cherryLog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cherryLog.SetActive(true);
        }
    }
}
