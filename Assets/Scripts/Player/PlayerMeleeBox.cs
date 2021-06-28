using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBox : MonoBehaviour
{
    [SerializeField] float upwardKnockbackFactor;
    [SerializeField] float knockbackForce;
    [SerializeField] Transform HeroLocation;
    private float horizontalKnockback;
    private float verticalKnockback;
    private BoxCollider2D attackBoxCollider;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        attackBoxCollider = gameObject.GetComponent<BoxCollider2D>();
        horizontalKnockback = upwardKnockbackFactor;
        verticalKnockback = knockbackForce;
    }
/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            print("hit!");
            collision.gameObject.GetComponent<Health>().takeDamage(damage);
            if (transform.position.y < collision.transform.position.y)
            {
                horizontalKnockback *= 4;
                verticalKnockback /= 2;
            }


        }
        if (HeroLocation.transform.position.x < collision.transform.position.x)
            collision.gameObject.GetComponent<Knockback>().InitiateKnockback(1, verticalKnockback, horizontalKnockback);
        else
            collision.gameObject.GetComponent<Knockback>().InitiateKnockback(-1, verticalKnockback, horizontalKnockback);
        horizontalKnockback = upwardKnockbackFactor;
        verticalKnockback = knockbackForce;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
            print("hit!");
         collision.gameObject.GetComponent<Health>().takeDamage(damage);
            if (transform.position.y < collision.transform.position.y)
            {
                horizontalKnockback *= 4;
                verticalKnockback /= 2;
            }
        if (collision.tag == "Enemy")
        {
            if (HeroLocation.transform.position.x < collision.transform.position.x)

                collision.gameObject.GetComponent<EnemyKnockback>().InitiateKnockback(1, verticalKnockback, horizontalKnockback);
            else
                collision.gameObject.GetComponent<EnemyKnockback>().InitiateKnockback(-1, verticalKnockback, horizontalKnockback);
            horizontalKnockback = upwardKnockbackFactor;
            verticalKnockback = knockbackForce;
        }


    }

}
