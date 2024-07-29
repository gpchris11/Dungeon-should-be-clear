using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public enum enumHitType
    {
        None,
        BodyCheck,
        AttackCheck,
        GroundCheck,
        DistanceCheck,
    }
    [SerializeField] protected enumHitType hitBoxType;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
