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

    public AudioSource jumpSound, insertSound, pickupSound;

    void Start()
    {
        checkGroundRadius = 0.01f;
        speed = 10;
        jumpForce = 15;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        HandleItems();

        QuitGame();
    }

    private void HandleItems()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Machine[] machines = FindObjectsOfType<Machine>();
            foreach (Machine machine in machines)
            {
                if (Vector2.Distance(machine.transform.position, transform.position) < 1)
                {
                    if (machine.InsertItem(itemInHands))
                    {
                        itemInHands = null;
                        insertSound.Play();
                        return;
                    }
                    else
                    {
                        print("not the right item or machine already has an item in it");
                    }
                }
            }

            Item[] allItems = FindObjectsOfType<Item>();
            foreach (Item item in allItems)
            {
                if (Vector2.Distance(item.transform.position, transform.position) < 1)
                {
                    if (itemInHands != item)
                    {
                        if (itemInHands != null)
                        {
                            itemInHands.transform.SetParent(null);
                            itemInHands.transform.position = transform.position;
                            itemInHands = null;
                        }

                        if (item.machine != null)
                        {
                            item.transform.SetParent(null);
                            item.machine.RemoveItem();
                            item.machine = null;
                        }

                        itemInHands = item;
                        item.transform.position = itemSlot.transform.position;
                        item.transform.SetParent(itemSlot);

                        pickupSound.Play();

                        return;
                    }
                }
            }

            LeverMachine[] leverMachines = FindObjectsOfType<LeverMachine>();
            foreach (LeverMachine leverMachine in leverMachines)
            {
                if (Vector2.Distance(leverMachine.transform.position, transform.position) < 1)
                {
                    leverMachine.ToggleOnOff();
                }
            }


            if (itemInHands != null)
            {
                itemInHands.transform.SetParent(null);
                itemInHands.transform.position = transform.position;
                itemInHands = null;
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
            jumpSound.Play();
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

    private void QuitGame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
