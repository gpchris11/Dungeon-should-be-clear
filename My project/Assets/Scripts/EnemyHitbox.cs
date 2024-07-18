using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : HitBox
{
    Enemy Enemy;

    private void Start()
    {
        Enemy = GetComponentInParent<Enemy>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy.TriggerEnter(collision, hitBoxType);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        Enemy.TriggerExit(collision, hitBoxType);
    }
}
