using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    //Vector3 startPos;
    //private void Start()
    //{
    //    startPos = transform.position;
    //}
    void Update()
    {
        if (player.position.y > -4.5 && player.position.y < 10)
            transform.position = new Vector3(player.position.x + 7, player.position.y, -1);
        else
            transform.position = new Vector3(player.position.x + 7, transform.position.y, -1);
    }
}
