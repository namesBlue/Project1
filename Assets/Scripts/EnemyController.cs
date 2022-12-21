using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D coll;

    public float speed; 

    public float jumpforce;

    [SerializeField]
    private bool isRight;

    private float timer;

    [SerializeField] private bool function_moveLeft;
    [SerializeField] private bool function_moveRight;
    [SerializeField] private bool function_jump;
    
    //private bool function_attach;

    //private int gravityDirection; // 0: down, 1: up， 2: right, 3: left

    //private RaycastHit2D left, right, up, down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();

        isRight = true;
        timer = 0f;
    }


    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {

        Vector2 left = new Vector3(transform.position.x-coll.bounds.size.x*0.5f, transform.position.y, transform.position.z);
        RaycastHit2D goLeft = Physics2D.Raycast(left, Vector2.down, coll.bounds.size.y/2+0.2f, (1<<8)|(1<<9)); // for movement
        RaycastHit2D turnRight = Physics2D.Raycast(left, Vector2.left, 0.05f, (1<<8)|(1<<9)); // for turn right

        Vector2 left1 = new Vector3(transform.position.x- coll.bounds.size.x*1.5f, transform.position.y, transform.position.z);
        RaycastHit2D goLeft1 = Physics2D.Raycast(left1, Vector2.down, coll.bounds.size.y/2+0.2f, (1<<8)|(1<<9)); // for further movement
        RaycastHit2D turnRight1 = Physics2D.Raycast(left1, Vector2.left, 0.05f, (1 << 8) | (1 << 9)); // for turn right

        Vector2 left2 = new Vector3(transform.position.x - coll.bounds.size.x * 2.5f, transform.position.y, transform.position.z);
        RaycastHit2D goLeft2 = Physics2D.Raycast(left2, Vector2.down, coll.bounds.size.y/2+3f, (1<<8)|(1<<9)); // for jump
        RaycastHit2D turnRight2 = Physics2D.Raycast(left2, Vector2.left, 0.05f, (1<<8)|(1<<9)); // for turn right

        Vector2 right = new Vector3(transform.position.x+ coll.bounds.size.x*0.5f, transform.position.y, transform.position.z);
        RaycastHit2D goRight = Physics2D.Raycast(right, Vector2.down, transform.localScale.y/2+0.2f, (1<<8)|(1<<9));
        RaycastHit2D turnLeft = Physics2D.Raycast(right, Vector2.right, 0.05f, (1<<8)|(1<<9));

        Vector2 right1 = new Vector3(transform.position.x+ coll.bounds.size.x*1.5f, transform.position.y, transform.position.z);
        RaycastHit2D goRight1 = Physics2D.Raycast(right1, Vector2.down, coll.bounds.size.y/2+0.2f, (1<<8)|(1<<9));
        RaycastHit2D turnLeft1 = Physics2D.Raycast(right, Vector2.right, 0.05f, (1 << 8) | (1 << 9));

        Vector2 right2 = new Vector3(transform.position.x + coll.bounds.size.x * 2.5f, transform.position.y, transform.position.z);
        RaycastHit2D goRight2 = Physics2D.Raycast(right2, Vector2.down, coll.bounds.size.y/2+3f, (1<<8)|(1<<9));
        RaycastHit2D turnLeft2 = Physics2D.Raycast(right2, Vector2.right, 0.05f, (1<<8)|(1<<9));

        if((goLeft | goRight))
        {
            if(function_moveLeft)
            {
                isRight = false;
                if(goLeft && !turnRight)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else if (goLeft1 && !turnRight1)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            else if(function_moveRight)
            {
                isRight = true;
                if(goRight && !turnLeft)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else if (goRight1 && !turnLeft1)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            else if(function_jump)
            {
                timer += Time.fixedDeltaTime;
                if(timer >= 0.5f)
                {
                    timer = 0f;
                    if (isRight)
                    {
                        if(goRight2 && !turnLeft2)
                        {
                            rb.velocity = new Vector2(speed * 3f, jumpforce);
                        }
                        else
                        {
                            isRight = false;
                        }

                    }
                    else
                    {
                        if (goLeft2 && !turnRight2)
                        {
                            rb.velocity = new Vector2(-speed * 3f, jumpforce);
                        }
                        else
                        {
                            isRight = true;
                        }
                    }
                }
            }
            else if(isRight)
            {
                if(goRight && !turnLeft)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else if (goRight1 && !turnLeft1)
                {

                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }

                else if(goLeft)
                {
                    isRight = false;
                }
            }
            else
            {
                if(goLeft && !turnRight)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else if (goLeft1 && !turnRight1)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else if(goRight)
                {
                    isRight = true;

                }
            }
        }      
    }


    //void Detection()
    //{
    //    left = Physics2D.Raycast(transform.position, Vector2.left, transform.localScale.x/2+0.05f, (1<<8)|(1<<9));
    //    right = Physics2D.Raycast(transform.position, Vector2.right, transform.localScale.x/2+0.05f, (1<<8)|(1<<9));
    //    up = Physics2D.Raycast(transform.position, Vector2.up, transform.localScale.y/2+0.05f, (1<<8)|(1<<9));
    //    down = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y/2+0.05f, (1<<8)|(1<<9));
    //}

    public void MoveLeft()
    {
        //print("move left");
        function_moveLeft = true;
        
    }
    public void StopMoveLeft()
    {
        function_moveLeft = false;
    }

    public void MoveRight()
    {
        //print("move right");
        function_moveRight = true;
       
    }

    public void StopMoveRight()
    {
        function_moveRight = false;
    }

    public void Jump()
    {
        function_jump = true;
        
        
    }

    public void StopJump()
    {
        //print("stop");
        function_jump = false;
    }

    public void Attach()
    {
        // Detection();
        // if(down)
        // {

        // }
        // else 
        // {
        //     Vector2 force1 = new Vector2(0f, -rb.gravityScale);
        //     rb.AddForce(force1);
        //     if(up)
        //     {
        //         Vector2 force2 = new Vector2(0f, rb.gravityScale);
        //         rb.AddForce(force2);
        //     }
        //     else if(right)
        //     {
        //         Vector2 force2 = new Vector2(rb.gravityScale, 0f);
        //         rb.AddForce(force2);
        //     }
        //     else if(left)
        //     {
        //         Vector2 force2 = new Vector2(-rb.gravityScale, 0f);
        //         rb.AddForce(force2);
        //     }

        // }
    } 

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Platform")
        {
            float scale_x = coll.bounds.size.x/2-0.1f;
            float scale_y = coll.bounds.size.y/2-0.1f;
            
            Vector3 pos1 = new Vector3(transform.position.x-scale_x, transform.position.y-scale_y, transform.position.z);

            Vector3 pos2 = new Vector3(transform.position.x+scale_x, transform.position.y-scale_y, transform.position.z);

            Vector3 pos3 = new Vector3(transform.position.x-scale_x, transform.position.y+scale_y, transform.position.z);

            Vector3 pos4 = new Vector3(transform.position.x+scale_x, transform.position.y+scale_y, transform.position.z);

            Bounds platformBounds = other.gameObject.GetComponent<Renderer>().bounds;
            if(platformBounds.Contains(pos1) | platformBounds.Contains(pos2) | platformBounds.Contains(pos3) | platformBounds.Contains(pos4))
            {
                Death();
                print("death");
            }
        }
    }  

    public void Death()
    {
        Destroy(gameObject);
    }
}
