using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamesCode
{
    public class PlayerInput : MonoBehaviour
    {
        public PlayerController2D playerController;
        bool jump = false;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Jump"))
            {
                jump = true;
            }
        }
        void FixedUpdate()
        {
            playerController.Move(jump);
            jump = false;
        }
    }
}
