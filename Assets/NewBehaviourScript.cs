using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamesCode
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private Rigidbody2D rb2D;
        public float launchSpeed = 2f;
        // Start is called before the first frame update
        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                rb2D.velocity *= new Vector2(launchSpeed, 0);
            }
            if (Input.GetButtonDown("Fire2"))
            {

            }
        }
    }
}
