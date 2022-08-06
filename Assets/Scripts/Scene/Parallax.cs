using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float moveRate;
    public bool lockY;
    public bool lockX;
    public bool moveWith;
    public Transform player;
    private float startPointX;
    private float startPointY;

    void Start()
    {
        startPointX = transform.position.x;
        startPointY = transform.position.y;
    }

    void Update()
    {
        if(lockY)
        {
            transform.position = new Vector2(startPointX + Cam.position.x * moveRate, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(startPointX + Cam.position.x * moveRate, startPointY + Cam.position.y * moveRate);
        }
        if(lockX)
        {
            transform.position = new Vector2(transform.position.x, startPointY + Cam.position.y * moveRate);
        }
        if(moveWith)
        {
            transform.position = new Vector3(0, player.position.y, -10f);
        }
    }
}
