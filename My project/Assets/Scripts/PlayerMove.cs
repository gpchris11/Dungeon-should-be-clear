using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [Header("�÷��̾� �̵�,����")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;


    [Header("�÷��̾� IsGround")]
    [SerializeField] bool isGround;
    [SerializeField] bool ShowGroundLength;
    [SerializeField] float GroundLengthCheck;
    [SerializeField] Color GroundLengthColor;

    Vector3 movedir;// 0 0 0
    Rigidbody2D rigid;//null
    Animator anim;
    [SerializeField] float vertivalVelocity = 0f;

    bool isjump;

    Camera cam;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {

        checkGround();
        MoveFunction();
        watchDir();
        jump();

        doAnim();
    }

    private void OnDrawGizmos()
    {
        if(ShowGroundLength == true)
        {
            Vector2 curPos = transform.position;
            Debug.DrawLine(transform.position, curPos - new Vector2(0, GroundLengthCheck), GroundLengthColor);
            //����,��,��
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
        movedir.y = rigid.velocity.y;
        rigid.velocity = movedir;
        //�¿�� ������ ���� A,D,����Ű ������ 1�� ���� ���� �ƹ��͵� �ȴ����� 0 ��ǻ������ ��Ű�� ����
        //������ ���� �̵���
        //y 0, time.deltaTime;
    }

    private void watchDir()
    {
        Vector3 dir = transform.localScale;
        if (movedir.x < 0 && dir.x != 1.0f)
        {
            dir.x = -3.6984f;
            transform.localScale = dir;
        }
        if (movedir.x > 0 && dir.x != -1.0f)
        {
            dir.x = 3.6984f;
            transform.localScale = dir;
        }
    }
    private void doAnim()
    {
        anim.SetInteger("Horizontal", (int)movedir.x);
        anim.SetBool("IsGround", isGround);
    }
    
    private void jump()
    {
        
        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            Debug.Log("���� ����");
        }
        //if (isGround == false)
        //{
        //    vertivalVelocity += Physics.gravity.y * Time.deltaTime;
        //    Vector2 vecVel = rigid.velocity;
        //    vecVel.y = vertivalVelocity;
        //    rigid.velocity = vecVel;
        //    //�߷�                    

        //}
    }
}
