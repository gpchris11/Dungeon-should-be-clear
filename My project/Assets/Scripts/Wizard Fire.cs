using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFire : MonoBehaviour
{
    float moveSpeed = 1f;
    Transform PlayerPos;
    Vector2 dir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);//총알 본인이 삭제
            Player player = collision.GetComponent<Player>();
            player.Hit(1);
        }
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);//총알 본인이 삭제
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Hit(0);
        }
    }

    void Start()
    {
        PlayerPos = GameObject.Find("Player").GetComponent<Transform>();
        dir = PlayerPos.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
