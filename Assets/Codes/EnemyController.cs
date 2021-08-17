using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float enemySpeed = 3.0f;
    public float changeTime = 3.0f;
    public bool isVertical;
    float timer;
    int direction = 1;
    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            direction = -direction;
            timer = changeTime;
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        if(isVertical)
        {
            position.y = position.y + enemySpeed * Time.deltaTime*direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + enemySpeed * Time.deltaTime * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2D.MovePosition(position);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();
        if(player !=null)
        {
            player.ChangeHealth(-1);
        }
    }


}
