using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float moveForce;
    public float maxSpeed;
    public float jumpForce;
    public bool canJump;
    public Rigidbody2D rb;
    public bool grounded;
    public Transform groundCheck;



    private void Awake()
    {
        moveForce = 4;
        maxSpeed = 6;
        jumpForce = 5;
        canJump = true;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        grounded = false;
        groundCheck = transform.GetChild(0);

    }

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position/*, 1 << LayerMask.NameToLayer("Ground")*/);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            canJump = true;
        }
    }

    void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        /*
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
            */
        if (canJump)
        {
            //anim.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce));
            canJump = false;
        }


        /*
        float y = rb.velocity.y;

        
        
        if (grounded)
        {
            y = 0;
            canJump = true;
        }
        else
        {
            y = Mathf.Lerp(y, -2, 1f);
        }

        if (canJump && Input.GetButtonDown("Jump"))
        {
            y = jumpForce*5;
            //rb.AddForce(new Vector2(0f, jumpForce));
            canJump = false;
            grounded = false;
        }

        Vector2 direction = new Vector2(Input.GetAxis("Horizontal") * speed, y);
        

        rb.velocity = direction;
        */
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.contacts.Length > 0)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
                { // if player touch the ground
                    grounded = true;
                    canJump = true;
                    break;
                }
                else if (Mathf.Abs(Vector2.Dot(contact.normal, new Vector2(1,0))) == 1 )
                {// If player touches a perpendicular wall
                    canJump = true;
                    //TODO add lateral forces to project player to the opposite way
                }
            }
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
                { // if player touch the ground
                    grounded = true;
                    canJump = true;
                    break;
                }
                else if (Mathf.Abs(Vector2.Dot(contact.normal, new Vector2(1, 0))) == 1)
                {// If player touches a perpendicular wall
                    canJump = true;
                    //TODO add lateral forces to project player to the opposite way
                }
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
        canJump = false;
    }
    */
}
