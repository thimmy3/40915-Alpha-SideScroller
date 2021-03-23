using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//James Code

public abstract class PlayerAttack : MonoBehaviour
{
    [Header("Shared Variables")]
    public float specialPower = 0;
    public Image powerBar;

    private GameObject meleeHitbox;

    public virtual void Start()
    {
        meleeHitbox = transform.Find("MeleeHitBox").gameObject;
    }

    public void DisplaySpecialPower(float value)
    {
        specialPower = Mathf.Clamp(value, 0, 1);
        powerBar.fillAmount = specialPower;
        powerBar.color = Color.HSVToRGB((specialPower - 0.2f) * 2 / 3f, 1, 1);
    }

    public virtual bool MeleeAttack()
    {
        if (!meleeHitbox.activeSelf)
        {
            meleeHitbox.SetActive(true);
            return true;
        }
        return false;
    }

    public virtual bool SpecialAttack()
    {
        if (specialPower == 1)
        {
            DisplaySpecialPower(0);
            return true;
        }
        return false;
    }
}
