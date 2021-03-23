using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JamesCode
{
    public class MoveEnvironment : MonoBehaviour
    {
        [SerializeField] private float fixedX = -5f;
        [SerializeField] private Transform envParent;
        [Range(0, 5f)] [SerializeField] private float smoothDampSpeed = 0.01f;
        private Vector2 refVelocity = Vector3.zero;
        public Sprite stars, clouds, sun, moon, blank;
        Camera cam;
        float daylight = 1f;
        bool night = false;
        int brighten = -1;
        private void Start()
        {
            cam = Camera.main;
        }
        void LateUpdate()
        {
            Vector2 targPos = Vector2.SmoothDamp(transform.position, new Vector2(fixedX, transform.position.y), ref refVelocity, smoothDampSpeed * Time.deltaTime);
            float diffX = transform.position.x - targPos.x;
            transform.position = targPos;

            daylight += diffX * brighten * Time.deltaTime * 0.1f;
            if (daylight < 0)
            {
                brighten = 1;
                daylight = 0;
            }
            else if (daylight > 1)
            {
                brighten = -1;
                daylight = 1;
            }
            cam.backgroundColor = Color.HSVToRGB(210f / 360f, 0.5f, daylight);
            bool newNight = false;
            bool newDay = false;
            if (!night && daylight < 0.5f)
            {
                night = true;
                newNight = true;
            }
            else if (night && daylight > 0.5f)
            {
                night = false;
                newDay = true;
            }
            foreach (Transform child in envParent)
            {
                if (child.CompareTag("Background"))
                {
                    SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

                    float backgroundWidth = sr.sprite.bounds.size.x;
                    child.position = new Vector2(child.position.x - (diffX * child.GetComponent<ParallaxStrength>().parallaxEffect), child.position.y);

                    if (child.name == "Background")
                    {
                        if (newNight && sr.sprite != moon)
                        {
                            if (child.position.x <= -backgroundWidth / 2 || child.position.x >= backgroundWidth / 2)
                                sr.sprite = moon;
                        }
                        else if (newDay && sr.sprite != sun)
                        {
                            if (child.position.x <= -backgroundWidth / 2 || child.position.x >= backgroundWidth / 2)
                                sr.sprite = sun;
                        }
                    }

                    if (child.position.x < -backgroundWidth - 2)
                    {
                        child.position = new Vector2(child.position.x + (3 * backgroundWidth), child.position.y);
                        if (daylight > 0.75f)
                        {
                            if (child.name == "Midground1" && sr.sprite != blank)
                            {
                                sr.sprite = blank;
                            }
                        }
                        else if (daylight > 0.5f)
                        {
                            if (child.name == "Midground1" && sr.sprite != clouds)
                            {
                                sr.sprite = clouds;
                                sr.sortingOrder = 0;
                            }
                            else if (child.name == "Background" && sr.sprite != sun)
                                sr.sprite = sun;
                        }
                        else
                        {
                            if (child.name == "Midground1" && sr.sprite != stars)
                            {
                                sr.sprite = stars;
                                sr.sortingOrder = -2;
                            }
                            else if (child.name == "Background" && sr.sprite != moon)
                                sr.sprite = moon;
                        }
                    }
                }
                else
                    child.position = new Vector2(child.position.x - diffX, child.position.y);
            }
        }
    }
}
