using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("�÷��̾� �̵�,����")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;
    Vector3 movedir;// 0 0 0
    Rigidbody2D rigid;//null
    Animator anim;
    float vertivalVelocity = 0f;

    [Header("�÷��̾� IsGround")]
    [SerializeField] bool isGround;
    [SerializeField] bool ShowGroundLength;
    [SerializeField] float GroundLengthCheck;
    [SerializeField] Color GroundLengthColor;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {

    }


    void Update()
    {
        checkGround();
        MoveFunction();

        doAnim();
    }

    private void OnDrawGizmos()
    {
        if(ShowGroundLength == true)
        {
            Vector2 curPos = transform.position;
            Debug.DrawLine(transform.position, curPos - new Vector2(0, GroundLengthCheck), GroundLengthColor);
                                  //      ����         /                          ��                                  /       ��         /
        }
    }

    private void checkGround() //RayCast�� Ground��� Layer�� �¾Ҵ��� Ȯ�� �´ٸ� IsGround = true,���� �ʾҴٸ� IsGround = false
    {
        isGround = false;

        if (vertivalVelocity > 0f) //���� �������� �������� ���� 0���� ũ�ٸ� Raycast�� ������ ����
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,     Vector2.down,     GroundLengthCheck,            LayerMask.GetMask("Ground"));
        //                                  �÷��̾� ��ġ����       Vector2(0, -1)��  GroundLengthCheck��ŭ������       Ground��� ���̾ �¾Ҵ���
        //�÷��̾� ��ġ���� �ؿ� �������� GroundLengthCheck�� ��ŭ Raycast�� ������ Ground��� Layer�� Raycast�� �¾Ҵ��� Ȯ��

        if (hit)
        {
            isGround = true;
        }
    }

    private void MoveFunction()
    {
        movedir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        rigid.velocity = movedir;
        movedir.y = rigid.velocity.y;
        //�¿�� ������ ���� A,D,����Ű ������ 1�� ���� ���� �ƹ��͵� �ȴ����� 0 ��ǻ������ ��Ű�� ����
        //������ ���� �̵���
        //y 0, time.deltaTime;
    }
    private void doAnim()
    {
        anim.SetInteger("Horizontal", (int)movedir.x);
        anim.SetBool("IsGround", isGround);
    }    
}
