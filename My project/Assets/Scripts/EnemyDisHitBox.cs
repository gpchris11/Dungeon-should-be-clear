using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisHitBox : HitBox
{
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.TriggerEnter(collision, hitBoxType);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        enemy.TriggerExit(collision, hitBoxType);
    }

}
