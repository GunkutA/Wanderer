using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int maxHealth = 5;
    float horizontal;
    float vertical;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    public int health { get { return currentHealth; } }
    int currentHealth;
    public float speed=3.0f;
    void Start()
    {
        //  QualitySettings.vSyncCount = 0;
        //  Application.targetFrameRate = 10;
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
       // Debug.Log( isInvincible +" / "+ invincibleTimer);
        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer<0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount<0)
        {
            if (isInvincible)
            {
                return;
            }     
            isInvincible = true;
            invincibleTimer = timeInvincible;

        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth +"/" + maxHealth);
    }
}
