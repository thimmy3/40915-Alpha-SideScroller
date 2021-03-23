﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol: MonoBehaviour
{
    public float speed;
    //public float distance;
    //public bool movingLeft = true;
    //public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //code below used if gaps appeared in ground, so enemies wouldn't walk off
        //ground gaps not featured so functionality disabled
        /*RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingLeft = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }*/
    }
}
