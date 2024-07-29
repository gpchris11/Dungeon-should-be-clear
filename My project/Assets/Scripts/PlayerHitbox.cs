using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : HitBox
{
    Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        player.TriggerEnter(collision, hitBoxType);
    }
    //protected override void OnTriggerExit2D(Collider2D collision)
    //{
    //    player.TriggerExit(collision, hitBoxType);
    //}
}
