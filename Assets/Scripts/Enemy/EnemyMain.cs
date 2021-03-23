using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public float collisionForce;

    Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) > 2.5)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            PushKill(collision.transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            PushKill(collision.transform.position);
        }
    }
    void PushKill(Vector2 contact)
    {
        Vector2 pos = transform.position;
        Debug.Log((pos - contact).normalized);
        rb2D.AddForce((pos - contact).normalized * collisionForce);
        GetComponent<Collider2D>().enabled = false;
    }

}
