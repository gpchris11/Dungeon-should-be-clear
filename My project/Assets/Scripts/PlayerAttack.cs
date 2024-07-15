using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    [Header("���� ����")]
    [SerializeField] private float AttackTime = 0.4f;
    [SerializeField] private float AttackDmg = 1.0f;
    float AttackTimer = 0.0f;
    [SerializeField] bool Attacked = false;

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//���콺 ���ʹ�ư�� ������ ��
        {
            Attacked = true;//Attacked�� true
        }
        if(Attacked == true)//Attacked�� true���
        {
            anim.SetTrigger("Attacks");//Attacks ����
        }


    }
    private void AtkTimer()
    {
        if(Attacked == true)//Attacked�� true���
        {
            AttackTimer += Time.deltaTime;//�ð��� �帧
        }
        if (AttackTimer < AttackTime)//�帥 �ð��� AttackTime ���� ª�ٸ�
        {
            Attacked = false;//Attacked�� false
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
