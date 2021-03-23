using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    public float speed;
    private float spriteWidth;
    private Camera cam;
    private void Start()
    {
        spriteWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        cam = Camera.main;
    }
    private void Update()
    {
        float endX = cam.ViewportToWorldPoint(Vector3.zero).x * 2.5f;//-cam.orthographicSize * Screen.width / Screen.height * 2;

        foreach (ParallaxStrength strength in GetComponentsInChildren<ParallaxStrength>())
        {
            Transform childTransform = strength.transform;
            childTransform.Translate(Vector2.left * strength.parallaxEffect * speed * Time.deltaTime);
            if (childTransform.position.x <= endX)
            {
                Vector2 pos = new Vector2(childTransform.position.x + (transform.childCount * spriteWidth), 0);
                childTransform.localPosition = pos;

            }
        }
    }

}
