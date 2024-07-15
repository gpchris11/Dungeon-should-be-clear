using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Movespeed;
    float rightmax = 2f;
    float leftmax = -2f;
    float currentPos;
    Rigidbody2D rigid;
    Animation anim;

    [SerializeField] bool isground;
    BoxCollider2D checkGroundColl;

    
    private void Move()
    {
        currentPos += Time.deltaTime * Movespeed;
        if(currentPos >= rightmax) 
        {
            Movespeed *= -1;
            currentPos = rightmax;
        }
        else if (currentPos <= leftmax) 
        {
            Movespeed *= -1;
            currentPos = leftmax;
        }   
        transform.position = new Vector3(currentPos, 1, 0);
        
    }

    void Start()
    {
        currentPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Awake()
    {
        anim = GetComponent<Animation>();
        rigid = GetComponent<Rigidbody2D>();
        checkGroundColl= GetComponentInChildren<BoxCollider2D>();
    }
}
