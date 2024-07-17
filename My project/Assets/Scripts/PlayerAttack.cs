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
        if (Input.GetKeyDown(KeyCode.Mouse0) && AttackTimer == 0.0f)//���콺 ���ʹ�ư�� ������ ��
        {
            Attacked = true;//Attacked�� true
            anim.SetTrigger("Attacks");//Attacks ����
        }
    }

    private void AtkTimer()
    {
        if (Attacked == true)//Attacked�� true���
        {
            AttackTimer += Time.deltaTime;//�ð��� �帧
            if (AttackTimer > AttackTime)//�帥 �ð��� AttackTime ���� ª�ٸ�
            {
                Attacked = false;//Attacked�� false
                AttackTimer = 0.0f;
            }
        }
    }

    //private void Hit()
    //{
    //    //Hitbox.enabled = false;

    //    if (Attacked == true)
    //    {
    //        Hitbox.enabled = true;
    //    }
    //}
}
