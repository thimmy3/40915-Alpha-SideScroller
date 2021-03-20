using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    public Rigidbody2D fireBall;
    public float fireBallSpeed = 8f;
    public float startTimeBTWShots;

    private float timeBTWShots;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBTWShots <= 0)
        {
            Instantiate(fireBall, transform.position, Quaternion.identity);
            timeBTWShots = startTimeBTWShots;
            
        }
        else
        {
            timeBTWShots -= Time.deltaTime;
        }
    }
}
