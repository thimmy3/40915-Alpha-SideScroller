using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDeactivate : MonoBehaviour
{
    public float meleeTimeMax = 2;

    float meleeTime;
    // Start is called before the first frame update
    void OnEnable()
    {
        meleeTime = meleeTimeMax;
    }
    void Update()
    {
        if (meleeTime > 0 || gameObject.activeSelf)
        {
            meleeTime -= Time.deltaTime;
            if (meleeTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
