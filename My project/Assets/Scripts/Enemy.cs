using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Movespeed;
    //float rightmax = 2f;
    //float leftmax = -2f;
    float currentPos;
    Vector3 movedir;
    Rigidbody2D rigid;
    Animation anim;

    public int NextMove;
    bool isMove;
    [SerializeField] float MoveTimer;
    [SerializeField] float MoveTime;
    [SerializeField] float StopTime;

    [SerializeField] bool isground;
    BoxCollider2D checkGroundColl;
   
    private void Awake()
    {
        anim = GetComponent<Animation>();
        rigid = GetComponent<Rigidbody2D>();
        checkGroundColl= GetComponentInChildren<BoxCollider2D>();
    }

    void Start()
    {
        //currentPos = transform.position.x;
        NextMove = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        choseMove();
    }

    private void choseMove()
    {
        isMove = false;
        NextMove = Random.Range(-1, 2);
        //InvokeRepeating("choseMove", 2f, 3f);
        if (NextMove != 0) 
        {
            MoveTimer += Time.deltaTime;
            if ( MoveTime < MoveTimer )
            {
                isMove = true;
                MoveTimer = 0;
            }
        }
        if(NextMove == 0)
        {
            MoveTimer += Time.deltaTime;
            if ( StopTime < MoveTimer )
            {
                MoveTimer = 0;
            }
        }
    }
    private void Move()
    {
        //정해진 위치에서 왔다갔다

        //currentPos += Time.deltaTime * Movespeed;
        //if(currentPos >= rightmax) 
        //{
        //    Movespeed *= -1;
        //    currentPos = rightmax;
        //}
        //else if (currentPos <= leftmax) 
        //{
        //    Movespeed *= -1;
        //    currentPos = leftmax;
        //}   
        //transform.position = new Vector3(currentPos, 1, 0);

        //랜덤값으로 움직임
        //rigid.velocity = new Vector2(NextMove, rigid.velocity.y);
        if (isMove == true)
        {
            movedir.x = NextMove * Movespeed;
            rigid.velocity = movedir;
        }
    }


   
}
