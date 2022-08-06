using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public void Death()
    {
        FindObjectOfType<PlayerController>().ChrryCount();
        Destroy(gameObject);
    }
}
