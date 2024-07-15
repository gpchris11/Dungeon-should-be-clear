using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    [Header("공격 관련")]
    [SerializeField] private float AttackTime = 0.4f;
    [SerializeField] private float AttackDmg = 1.0f;
    float AttackTimer = 0.0f;
    [SerializeField] bool Attacked = false;

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//마우스 왼쪽버튼을 눌렀을 때
        {
            Attacked = true;//Attacked는 true
        }
        if(Attacked == true)//Attacked가 true라면
        {
            anim.SetTrigger("Attacks");//Attacks 실행
        }


    }
    private void AtkTimer()
    {
        if(Attacked == true)//Attacked가 true라면
        {
            AttackTimer += Time.deltaTime;//시간이 흐름
        }
        if (AttackTimer < AttackTime)//흐른 시간이 AttackTime 보다 짧다면
        {
            Attacked = false;//Attacked는 false
        }
        if (AttackTimer > AttackTime)
        {
            Attacked = true;
            AttackTimer = 0.0f;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AtkTimer();
        Attack();
    }

   
}
