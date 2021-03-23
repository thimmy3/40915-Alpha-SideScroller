﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    private void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }
    private void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }
}
