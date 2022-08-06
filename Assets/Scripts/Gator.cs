using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : MonoBehaviour
{
    public GameObject WinUI;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            //WinUI.SetActive(true);
            WinUI.SetActive(true);
            PlayerController.instance.canMove = false;
        }
    }
}
