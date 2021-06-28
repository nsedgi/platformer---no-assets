using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private Health damageCheck;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x == 0 && damageCheck.isHit == false)
        {

            playerMovement.enabled = true;
        }
    }

    public void InitiateKnockback(float direction, float knockbackForce, float upwardKnockbackFactor)
    {
        playerMovement.enabled = false;
        body.velocity = new Vector2(direction*knockbackForce, body.velocity.y+upwardKnockbackFactor);
        damageCheck.isHit = false;
    }
}
