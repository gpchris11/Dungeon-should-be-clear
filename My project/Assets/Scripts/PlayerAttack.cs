using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    [Header("공격 관련")]
    [SerializeField]  float AttackTime = 0.4f;
    [SerializeField] float AttackDmg;
    float AttackTimer = 0.0f;
    [SerializeField] bool Attacked = false;
    BoxCollider2D Hitbox;

  


    
    void Start()
    {
        anim = GetComponent<Animator>();
        Hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AtkTimer();
        Attack();
        //Hit();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && AttackTimer == 0.0f)//마우스 왼쪽버튼을 눌렀을 때
        {
            Attacked = true;//Attacked는 true
            anim.SetTrigger("Attacks");//Attacks 실행
            
        }
    }

    private void AtkTimer()
    {
        if (Attacked == true)//Attacked가 true라면
        {
            AttackTimer += Time.deltaTime;//시간이 흐름
            if (AttackTimer > AttackTime)//흐른 시간이 AttackTime 보다 짧다면
            {
                Attacked = false;//Attacked는 false
                AttackTimer = 0.0f;
            }
        }
    }

    public void TriggerEnter(Collider2D _coll, HitBox.enumHitType _hitType)
    {
        switch (_hitType)
        {
            case HitBox.enumHitType.AttackCheck:
                if (_coll.CompareTag("Enemy"))
                {
                    Debug.Log((AttackDmg) + "의 데미지를 넣었습니다!");
                    Enemy enemy = _coll.gameObject.GetComponent<Enemy>();
                    enemy.Hit(AttackDmg);
                }
                break;
        }
    }
    //public void TriggerExit(Collider2D _coll, HitBox.enumHitType _hitType)
    //{
    //    switch (_hitType)
    //    {
    //        case HitBox.enumHitType.BodyCheck:
                
    //            break;
    //    }
    }
