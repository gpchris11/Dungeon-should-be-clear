using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Movespeed;
    //float rightmax = 2f;
    //float leftmax = -2f;
    float currentPos;
    Vector3 movedir;
    Rigidbody2D rigid;
    Animation anim;
    EdgeCollider2D edge;

    public int NextMove;
    [SerializeField] bool isMove;
    [SerializeField] float MoveTimer;
    [SerializeField] float MoveTime;
    [SerializeField] float StopTime;
    [SerializeField] float repeatTime;

    [SerializeField] bool touching;
    BoxCollider2D checkGroundColl;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        rigid = GetComponent<Rigidbody2D>();
        //checkGroundColl= GetComponentInChildren<BoxCollider2D>();
        //edge = GetComponent<EdgeCollider2D>();
    }

    void Start()
    {
        //currentPos = transform.position.x;
        //NextMove = Random.Range(-1, 2);
        InvokeRepeating("choseMove", MoveTime, repeatTime);
        touching = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //if (edge.IsTouchingLayers(LayerMask.GetMask("Ground")) == false)
        //{
        //    touching = false;
        //    repeatTime = 0;
        //}
    }

    private void choseMove()
    {
        Vector3 dir = transform.localScale;
        isMove = false;
        NextMove = Random.Range(-1, 2);//-1 ,0 ,1
        //InvokeRepeating("choseMove", 2f, 3f);
        if (NextMove != 0) //움직일수 있음
        {
            dir.x = 4 * -NextMove;
            transform.localScale = dir;
            isMove = true;
            MoveTimer += Time.deltaTime;//0에서 부터 시간이 흐름
            if (MoveTime < MoveTimer)//MoveTimer가 MoveTime보다 커지면 움직임 멈춤,MoveTimer 초기화
            {
                isMove = false;
                MoveTimer = 0;

            }
        }
        if (NextMove == 0)//움직일수 없음
        {
            MoveTimer += Time.deltaTime;//0에서 부터 시간이 흐름
            if (StopTime < MoveTimer)//MoveTimer가 StopTime보다 커지면 MoveTimer 초기화
            {
                MoveTimer = 0;
            }
        }
    }
    private void Move()
    {
        if (isMove == true)
        {
            //Vector3 dir = transform.localScale;
            movedir.x = NextMove * Movespeed;
            rigid.velocity = movedir;
            //if (nextmove == 1)
            //{
            //    dir.x = -4f;
            //}
            //if (nextmove == -1)
            //{
            //    dir.x = 4f;
            //}

        }
    }

    public void TriggerEnter(Collider2D _coll, HitBox.enumHitType _hitType)
    {
        switch (_hitType)
        {
            case HitBox.enumHitType.BodyCheck:
                break;
            case HitBox.enumHitType.AttackCheck:
                break;
            case HitBox.enumHitType.GroundCheck:
                if (_coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    touching = true;
                }
                break;
        }
    }
    public void TriggerExit(Collider2D _coll, HitBox.enumHitType _hitType)
    {
        switch (_hitType)
        {
            case HitBox.enumHitType.GroundCheck:
                if (_coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    touching = false;
                    NextMove = -NextMove;
                    Vector3 locS = transform.localScale;
                    locS.x *= -1;
                    transform.localScale = locS;
                }
                break;
        }
    }
}






