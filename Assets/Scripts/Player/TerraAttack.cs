using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraAttack : PlayerAttack
{
    [Header("Terra Variables")]
    public int numRocks;
    public GameObject rockPrefab;
    public float initialDelay, spawnDelay;

    private float rockWidth;

    public override void Start()
    {
        base.Start();
        rockWidth = rockPrefab.GetComponent<BoxCollider2D>().size.x / 2;
    }
    public override bool SpecialAttack()
    {
        if (specialPower == 1)
        {
            DisplaySpecialPower(0);
            StartCoroutine(TerraSpecialAttack());
            return true;
        }
        return false;
    }

    IEnumerator TerraSpecialAttack()
    {
        float startX = transform.position.x + 0.8f;
        yield return new WaitForSeconds(initialDelay);
        for (int i = 0; i < numRocks; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(rockPrefab, new Vector2(startX + (i * rockWidth), -1.335714f), Quaternion.identity);
        }
    }
}
