using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrobblinController : MonoBehaviour
{
    public float speed;

    float timeAlive = 0;
    float startX;
    private void Start()
    {
        startX = 5f + Random.Range(-1f, 1f);
        transform.position = new Vector3(startX, 0, 0);
    }

    private void Update()
    {
        timeAlive -= Time.deltaTime;
        transform.position = new Vector2(startX + timeAlive, Mathf.Sin(timeAlive) + 0.75f);
        if (transform.position.x < -5)
            Destroy(gameObject);
    }
}
