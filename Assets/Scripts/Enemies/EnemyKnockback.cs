using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Health damageCheck;
    [SerializeField] private EnemyBehavior enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x == 0 && damageCheck.isHit == false)
        {

            enemyMovement.isHurt = false;
        }

    }
    public void InitiateKnockback(float direction, float knockbackForce, float upwardKnockbackFactor)
    {
        body.velocity = Vector2.zero;
        enemyMovement.isHurt = true;
        body.velocity = new Vector2(direction * knockbackForce, body.velocity.y + upwardKnockbackFactor);

    }
}
