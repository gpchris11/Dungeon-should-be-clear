using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("플레이어 이동,점프")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;
    Vector3 movedir;

    [Header("플레이어 IsGround")]
    [SerializeField] bool isGround;
    [SerializeField] bool ShowGroundLength;
    [SerializeField] float GroundLengthCheck;
    [SerializeField] Color GroundLengthColor;

    float vertivalVelocity = 0f;


    void Start()
    {

    }


    void Update()
    {
        checkGround();
        MoveFunction();

    }

    private void OnDrawGizmos()
    {
        if(ShowGroundLength == true)
        {
            Vector2 curPos = transform.position;
            Debug.DrawLine(transform.position, curPos - new Vector2(0, GroundLengthCheck), GroundLengthColor);
                         //      시작         /                       끝                    /       색         /
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
        
    }

}
