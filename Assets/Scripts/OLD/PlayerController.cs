using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D myRigidBody;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D Enemy) 
    {
        
    }
}
