using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFire : MonoBehaviour
{
    float moveSpeed = 2f;
    Transform PlayerPos;
    Vector2 dir;
    bool isShootEnemy = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Player player = collision.GetComponent<Player>();
            player.Hit(1);
        }
        if (collision.tag == "Enemy")
        {
            
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
    public void shootEnemy()
    {
        isShootEnemy = false;
    }
}
