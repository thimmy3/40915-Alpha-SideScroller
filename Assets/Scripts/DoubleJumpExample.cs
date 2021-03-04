using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamesCode
{
    public class DoubleJumpExample : MonoBehaviour
    {
        private bool allowDoubleJump;
        private bool isGrounded;
        private float groundJumpForce, airJumpForce;
        private Rigidbody2D rb;
        private Transform groundCheck;
        private LayerMask groundLayer;

        private void Update()
        {
            rb = GetComponent<Rigidbody2D>();
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        public void FixedUpdate()
        {
            isGrounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                    allowDoubleJump = true;
                }
            }
        }


        public void Jump()
        {
            if (isGrounded)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0, groundJumpForce));
            }
            else if (allowDoubleJump)
            {
                allowDoubleJump = false;
                rb.AddForce(new Vector2(0, airJumpForce));
            }
        }
    }
}
