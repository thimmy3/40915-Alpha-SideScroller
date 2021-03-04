using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamesCode
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController2D : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2d;
        [SerializeField] private bool isGrounded;
        public float maxHorizontalVelocity = 50f;
        public float velocityIncrement = 0.001f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [Range(0, 0.3f)] [SerializeField] private float smoothDampSpeed = 0.05f;
        [SerializeField] private float jumpForce = 50f;

        private Vector2 refVelocity = Vector3.zero;
        // Start is called before the first frame update
        void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            maxHorizontalVelocity += velocityIncrement;
            bool wasGrounded = isGrounded;
            isGrounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                }
            }
        }

        public void Move(bool jump)
        {
            Vector2 targetVelocity = new Vector2(maxHorizontalVelocity, rigidbody2d.velocity.y);
            rigidbody2d.velocity = Vector2.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref refVelocity, smoothDampSpeed);
            if (jump && isGrounded)
            {
                isGrounded = false;
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            }
        }

    }
}
