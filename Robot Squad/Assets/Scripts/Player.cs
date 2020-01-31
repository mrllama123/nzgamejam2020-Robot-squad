using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float speed;
    float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    float checkGroundRadius;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        checkGroundRadius = 0.5f;
        speed = 10;
        jumpForce = 10;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // collider 
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // movement logic
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rigidbody2D.velocity = new Vector2(moveBy, rigidbody2D.velocity.y);
        //jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }
}
