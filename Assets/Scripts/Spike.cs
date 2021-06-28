using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float upwardKnockbackFactor;
    [SerializeField] float knockbackForce;
    [SerializeField] float damage;
    private float horizontalKnockback;
    private float verticalKnockback;
    // Start is called before the first frame update
    void Start()
    {
        horizontalKnockback = upwardKnockbackFactor;
        verticalKnockback = knockbackForce;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            print("TRAP!");
            collision.GetComponent<Health>().takeDamage(damage);
            if (transform.position.y < collision.transform.position.y)
            {
                horizontalKnockback *= 4;
                verticalKnockback /= 2;
            }

        }
            if (transform.position.x < collision.transform.position.x)
                collision.GetComponent<Knockback>().InitiateKnockback(1, verticalKnockback, horizontalKnockback);
            else
                collision.GetComponent<Knockback>().InitiateKnockback(-1, verticalKnockback, horizontalKnockback);
        horizontalKnockback = upwardKnockbackFactor;
        verticalKnockback = knockbackForce;
    }

}
