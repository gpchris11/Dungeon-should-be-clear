using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Wizfire;
    public GameObject WizfirePrefab;
    float AttackRate = 2f;
    Transform target;
    float AttackTimer;


    //float rightmax = 2f;
    //float leftmax = -2f;
    float currentPos;
    Vector3 movedir;
    Rigidbody2D rigid;
    Animator anim;
    

    public int NextMove;
    [SerializeField] bool isMove;
    [SerializeField] float MoveTimer;
    [SerializeField] float MoveTime;
    [SerializeField] float StopTime;
    [SerializeField] float repeatTime;
    protected bool isDead = false;
    bool Attack = false;

    [SerializeField] bool touching;
    BoxCollider2D checkGroundColl;

    [Header("적 프로퍼티")]
    [SerializeField] float Hp;
    [SerializeField] float Dmg;
    [SerializeField] float Movespeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        AttackTimer = 0f;

        
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
            //case HitBox.enumHitType.BodyCheck:
            //    if(_coll.CompareTag("Player"))
            //    {
            //        Debug.Log((Dmg) + "의 데미지를 받았습니다!");
            //        Player player = _coll.gameObject.GetComponent<Player>();
            //        player.Hit(Dmg);
            //    }
            //    break;

            case HitBox.enumHitType.GroundCheck: 
                if (_coll.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    touching = true;
                }
                break;
            case HitBox.enumHitType.DistanceCheck:
                if (_coll.CompareTag("Player"))
                {
                    SummoneFire();
                    //Debug.Log("플레이어를 확인했습니다.");
                    //Destroy(Move);
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

            case HitBox.enumHitType.DistanceCheck:
                if (_coll.CompareTag("Player"))
                {
                    Debug.Log("플레이어가 시야에서 벗어났습니다.");
                }
                break;

        }
    }
    //public void TriggerEnter(Collider2D _coll, HitBox.enumHitType _hitType)
    //{
    //    switch (_hitType)
    //    {
    //        case HitBox.enumHitType.BodyCheck:
    //            if (_coll.CompareTag("Enemy"))
    //            {
    //                Player.
    //            }
    //            break;
    //    }
    //}

    public void Hit(float _Dmg)
    {
        Hp -= _Dmg;
        
        if (Hp <= 0) 
        {
            anim.SetBool("IsDead", true);
            isDead = true;
            Invoke("DeadAnim", 0.3f);
            Debug.Log("적을 처치하였습니다.");
        }

    }

    public void DeadAnim()
    {
        Destroy(gameObject);
    }

    private void SummoneFire()
    {
        AttackTimer += Time.deltaTime;

        if (AttackTimer >= AttackRate)
        {
            AttackTimer = 0f;

            GameObject Wizfire = Instantiate(WizfirePrefab, transform.position, transform.rotation);

            Attack = true;
            anim.SetBool("Attack", true);
        }

    }

}






