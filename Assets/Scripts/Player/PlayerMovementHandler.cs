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
        public int grobblinsKilled = 0;
        public Rigidbody2D rigid2D;
        public Animator animator;
        public PlayerAttack playerAttack;
        // Start is called before the first frame update
        void Start()
        {
            rigid2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (!isGrounded)
                {
                    animator.SetTrigger("Land");
                    isGrounded = true;
                    jumps = 1;
                }
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                Time.timeScale = 0;
                Debug.Log("GAME OVER");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Grobblin"))
            {
                if (collision.gameObject.name == "GrobblinsGold")
                    playerAttack.DisplaySpecialPower(1);
                else
                    playerAttack.DisplaySpecialPower(playerAttack.specialPower + 0.2f);

                grobblinsKilled++;
                Destroy(collision.gameObject);
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
                animator.SetTrigger("Jump"); //plays the jump animation
                rigid2D.AddForce(Vector2.up * force); //moves the player character up
                jumps -= 1;
                isGrounded = false;

            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
            {
                if (playerAttack.MeleeAttack()) //if the conditions for a melee attack are allowed
                {
                    animator.SetTrigger("Attack"); //play the attack animation
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && isGrounded)
            {
                if (playerAttack.SpecialAttack()) //if the conditions for a special attack are allowed
                {
                    animator.SetTrigger("Attack"); //play the attack animation
                }
            }
        }

    }
}



