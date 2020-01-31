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

    public Item itemInHands;
    public Transform itemSlot;

    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        checkGroundRadius = 0.01f;
        speed = 10;
        jumpForce = 10;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        HandleItems();
    }

    private void HandleItems()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //if you have a item check if there is a machine to put it in to if its fit
            if (itemInHands != null)
            {
                Machine[] machines = FindObjectsOfType<Machine>();
                foreach (Machine machine in machines)
                {
                    if (Vector2.Distance(machine.transform.position, transform.position) < 1)
                    {
                        if (machine.InsertItem(itemInHands))
                        {
                            itemInHands = null;
                        }
                        else
                        {
                            print("not the right item");
                        }
                    }
                }
            }
            else
            {
                //if you don't have an item looks for all items in distance 
                Item[] allItems = FindObjectsOfType<Item>();
                foreach (Item item in allItems)
                {
                    if (Vector2.Distance(item.transform.position, transform.position) < 1)
                    {
                        if (itemInHands != item)
                        {
                            if (item.machine != null) //remove item from machin
                            {
                                item.machine.RemoveItem();
                                item.machine = null;
                            }
                            itemInHands = item;
                            item.transform.position = itemSlot.transform.position;
                            item.transform.SetParent(itemSlot);
                        }
                    }
                }
            }
        }
    }

    private void Movement()
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
        if (Input.GetAxisRaw("Vertical") > 0 && isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }

        Animations(x);
    }

    private void Animations(float x)
    {
        if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f)
        {
            animator.Play("walk");
            spriteRenderer.flipX = x < 0;
        }
        else
        {
            animator.Play("idle");
        }
    }
}
