using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodysCode
{

    public class PlayerMovementHandler : MonoBehaviour
    {
        public bool isGrounded = true;
        public int jumps;
        public float force;
        public Rigidbody2D rigid2D;
        // Start is called before the first frame update
        void Start()
        {
            rigid2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
                jumps = 1;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = false;

            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumps > 0))
            {
                rigid2D.AddForce(Vector2.up * force);
                jumps -= 1;

            }
        }


        // Update is called once per frame

    }





}



