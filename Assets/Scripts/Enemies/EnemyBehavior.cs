using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Transform groundDetection;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float attackDurationTimer;
    private bool isAttacking;
    public bool isHurt;
    private float initialCooldownTimer;
    private float initialAttackDurationTimer;
    private float direction=1f;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        initialCooldownTimer = cooldownTimer;
        initialAttackDurationTimer = attackDurationTimer;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        attackDurationTimer -= Time.deltaTime;
        if (attackDurationTimer < 0)
            attackDurationTimer = 0;

        if (isGrounded() && isAttacking == false&& isHurt==false)
        {
            body.velocity = new Vector2(direction * speed, body.velocity.y);
            if (body.velocity.x < 0.01f)
                transform.localScale = Vector2.one;
            if (body.velocity.x > -0.01f && isAttacking == false)
                transform.localScale = new Vector2(-1, 1);
        }
        if (attackDurationTimer <= 0)
            isAttacking = false;
        DetectGround();
        DetectPlayer();
 //       if (isAttacking == true)


    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isAttacking==false&& collision.gameObject.tag != "Player"&&collision.gameObject.tag != "PlayerAttack")
            direction *= -1;
    }

    private void DetectGround()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,2f);
        if (groundInfo.collider == null)
            direction *= -1;
    }
    private void DetectPlayer()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
            cooldownTimer = 0;
        RaycastHit2D playerInfo;
        if (direction>0)
        playerInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 1f);
        else
        playerInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, 1f);
        if(playerInfo.collider!=null)
            if (playerInfo.collider.tag == "Player"&&cooldownTimer<=0)
            {
                Attack();
            }
    }
    private void Attack()
    {
        isAttacking = true;
        body.velocity = Vector2.zero;
        attackDurationTimer = initialAttackDurationTimer;
        animator.SetTrigger("Attack");
        Cooldown();
    }

    private void Cooldown()
    {
        cooldownTimer =initialCooldownTimer;
    }
}
