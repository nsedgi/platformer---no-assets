using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float speed=5f;
    [SerializeField] private float jumpForce = 3;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool isJumping;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale = Vector2.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-1, 1);

        horizontalInput = Input.GetAxis("Horizontal");

        animator.SetBool("isGrounded", isGrounded());
        animator.SetBool("isRunning", horizontalInput != 0);
        animator.SetBool("isJumping", isJumping);


        if (Input.GetKeyDown(KeyCode.LeftAlt) && isGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
            body.velocity = new Vector2(body.velocity.x*jumpForce, body.velocity.y);

        if (body.velocity.y <= 0) {
            isJumping = false;


        }
        else if (body.velocity.y > 0)
        {
            isJumping = true;
        }

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return isGrounded()&&body.velocity.x<1&&body.velocity.x>-1;
    }
}

