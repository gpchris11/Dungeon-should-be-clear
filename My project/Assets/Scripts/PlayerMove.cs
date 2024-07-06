using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("플레이어 이동,점프")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;
    Vector3 movedir;// 0 0 0
    Rigidbody2D rigid;//null
    Animator anim;
    float vertivalVelocity = 0f;

    [Header("플레이어 IsGround")]
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
                                  //      시작         /                          끝                                  /       색         /
        }
    }

    private void checkGround() //RayCast가 Ground라는 Layer에 맞았는지 확인 맞다면 IsGround = true,맞지 않았다면 IsGround = false
    {
        isGround = false;

        if (vertivalVelocity > 0f) //만약 수직으로 떨어지는 힘이 0보다 크다면 Raycast를 보내지 않음
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,     Vector2.down,     GroundLengthCheck,            LayerMask.GetMask("Ground"));
        //                                  플레이어 위치에서       Vector2(0, -1)로  GroundLengthCheck만큼보내서       Ground라는 레이어에 맞았는지
        //플레이어 위치에서 밑에 방향으로 GroundLengthCheck를 만큼 Raycast를 보내어 Ground라는 Layer에 Raycast가 맞았는지 확인

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
        //좌우로 움직임 구현 A,D,방향키 누르면 1의 값을 넣음 아무것도 안누르면 0 컴퓨터한테 시키는 거임
        //물리에 의해 이동함
        //y 0, time.deltaTime;
    }
    private void doAnim()
    {
        anim.SetInteger("Horizontal", (int)movedir.x);
        anim.SetBool("IsGround", isGround);
    }    
}
