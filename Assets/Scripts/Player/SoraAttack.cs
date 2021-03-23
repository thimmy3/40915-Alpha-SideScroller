using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoraAttack : PlayerAttack
{
    [Header("Sora Variables")]
    public float windSpeed;
    public GameObject windPrefab;

    private bool specialAttack;
    private GameObject windAttack;
    public override bool SpecialAttack()
    {
        if (specialPower == 1)
        {
            DisplaySpecialPower(0);
            specialAttack = true;
            return true;
        }
        return false;
    }
    public void SoraSpecialAttack()
    {
        if (specialAttack)
        {
            if (windAttack != null)
                Destroy(windAttack);
            windAttack = Instantiate(windPrefab);
            windAttack.transform.position = new Vector2(transform.position.x + 0.6f, -1.3f);
            specialAttack = false;
        }
    }
    public void Update()
    {
        if (windAttack != null)
        {
            Transform windTransform = windAttack.transform;
            if (windTransform.position.x < 4)
                windTransform.Translate(Vector2.right * windSpeed * Time.deltaTime, Space.World);
            else
                Destroy(windAttack);
        }
    }
}
