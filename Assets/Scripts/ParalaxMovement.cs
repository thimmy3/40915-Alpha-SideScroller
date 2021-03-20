using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodysCode
{
    public class ParalaxMovement : MonoBehaviour
    {
        public float speed;
        public float endX;
        private Vector2 lastCameraPosition;
        private Transform cameraTransform;
        private void Start()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;

        }
        private void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if(transform.position.x <= endX)
            {
                Vector2 pos = new Vector2(transform.position.x + 90, transform.position.y);
                transform.position = pos;

            }
        }

    }
}

