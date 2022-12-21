using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    public bool back;
    public Transform left, right;
    private float leftLine, rightLine;
    public float goSpeed;
    public float backSpeed;

    private Trigger trigger;
    private bool onPlatform0;
    private bool onPlatform1;
    private bool onPlatform2;
    private bool onPlatform3;

    public Transform character;
    public Transform character1;
    public Transform character2;
    public Transform enemy;

    public Sprite backPic;
    public Sprite notBackPic;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponentInParent<Trigger>();

        right.position = transform.position;

        leftLine = left.position.x;
        rightLine = right.position.x;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (back)
        {
            spriteRenderer.sprite = backPic;
        }
        else
        {
            spriteRenderer.sprite = notBackPic;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement() // right to left
    {

        if (trigger.isTrigger)
        {
            //speed = new Vector2(goSpeed, 0);
            if (rightLine > leftLine)
            {
                if (transform.position.x >= leftLine)
                {
                    float x = transform.position.x - goSpeed * Time.fixedDeltaTime;
                    transform.position = new Vector3(x, transform.position.y, transform.position.z);

                    if(onPlatform0)
                    {
                        character.position = new Vector3(character.position.x - goSpeed * Time.fixedDeltaTime, character.position.y, character.position.z);
                        //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                        //rb.velocity = rb.velocity-speed;
                    }
                    if(onPlatform1)
                    {
                        character1.position = new Vector3(character1.position.x - goSpeed * Time.fixedDeltaTime, character1.position.y, character1.position.z);
                    }
                    if(onPlatform2)
                    {
                        character2.position = new Vector3(character2.position.x - goSpeed * Time.fixedDeltaTime, character2.position.y, character2.position.z);
                    }
                    if(onPlatform3)
                    {
                        enemy.position = new Vector3(enemy.position.x - goSpeed * Time.fixedDeltaTime, enemy.position.y, enemy.position.z);
                    }

                }
            }
            else
            {
                if (transform.position.x <= leftLine)
                {
                    float x = transform.position.x + goSpeed * Time.fixedDeltaTime;
                    transform.position = new Vector3(x, transform.position.y, transform.position.z);

                    if(onPlatform0)
                    {
                        character.position = new Vector3(character.position.x + goSpeed * Time.fixedDeltaTime, character.position.y, character.position.z);
                        //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                        //rb.velocity = rb.velocity-speed;
                    }
                    if(onPlatform1)
                    {
                        character1.position = new Vector3(character1.position.x + goSpeed * Time.fixedDeltaTime, character1.position.y, character1.position.z);
                    }
                    if(onPlatform2)
                    {
                        character2.position = new Vector3(character2.position.x + goSpeed * Time.fixedDeltaTime, character2.position.y, character2.position.z);
                    }
                    if(onPlatform3)
                    {
                        enemy.position = new Vector3(enemy.position.x + goSpeed * Time.fixedDeltaTime, enemy.position.y, enemy.position.z);
                    }

                }
            }
        }
        else if(back)
        {
            //speed = new Vector2(backSpeed, 0);
            if (rightLine > leftLine)
            {
                if (transform.position.x <= rightLine)
                {
                    float x = transform.position.x + backSpeed * Time.fixedDeltaTime;
                    transform.position = new Vector3(x, transform.position.y, transform.position.z);

                    if(onPlatform0)
                    {
                        character.position = new Vector3(character.position.x + backSpeed * Time.fixedDeltaTime, character.position.y, character.position.z);
                        //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                        //rb.velocity = rb.velocity-speed;
                    }
                    if(onPlatform1)
                    {
                        character1.position = new Vector3(character1.position.x + backSpeed * Time.fixedDeltaTime, character1.position.y, character1.position.z);
                    }
                    if(onPlatform2)
                    {
                        character2.position = new Vector3(character2.position.x + backSpeed * Time.fixedDeltaTime, character2.position.y, character2.position.z);
                    }
                    if(onPlatform3)
                    {
                        enemy.position = new Vector3(enemy.position.x + backSpeed * Time.fixedDeltaTime, enemy.position.y, enemy.position.z);
                    }

                }
                // else
                // {
                //     transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                // }
            }
            else
            {
                if (transform.position.x >= rightLine)
                {
                    float x = transform.position.x - backSpeed * Time.fixedDeltaTime;
                    transform.position = new Vector3(x, transform.position.y, transform.position.z);

                    if(onPlatform0)
                    {
                        character.position = new Vector3(character.position.x - backSpeed * Time.fixedDeltaTime, character.position.y, character.position.z);
                        //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                        //rb.velocity = rb.velocity-speed;
                    }
                    if(onPlatform1)
                    {
                        character1.position = new Vector3(character1.position.x - backSpeed * Time.fixedDeltaTime, character1.position.y, character1.position.z);
                    }
                    if(onPlatform2)
                    {
                        character2.position = new Vector3(character2.position.x - backSpeed * Time.fixedDeltaTime, character2.position.y, character2.position.z);
                    }
                    if(onPlatform3)
                    {
                        enemy.position = new Vector3(enemy.position.x - backSpeed * Time.fixedDeltaTime, enemy.position.y, enemy.position.z);
                    }

                }
                // else
                // {
                //     transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                // }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // trigger information
        if (other.gameObject.tag == "Player")
        {
            onPlatform0 = true;
            trigger.isTrigger = true;
            trigger.isTrigger0 = true;
        }
        else if(other.gameObject.tag == "Player_part1")
        {
            onPlatform1 = true;
            trigger.isTrigger = true;
            trigger.isTrigger1 = true;


        }
        else if(other.gameObject.tag == "Player_part2")
        {
            onPlatform2 = true;
            trigger.isTrigger = true;
            trigger.isTrigger2 = true;
        }
        else if(other.gameObject.tag == "Enemy")
        {
            onPlatform3 = true;
            enemy = other.gameObject.transform;
        }


        if (other.gameObject.tag == "Enemy" && trigger.isTrigger == true)
        {
            if (trigger.functionNum == 0)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
            }

            else if (trigger.functionNum == 1)
            {

                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveLeft();
            }
            else if (trigger.functionNum == 2)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveRight();
            }
        }
        else if (other.gameObject.tag == "Enemy" && trigger.isTrigger == false)
        {
            other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
            other.gameObject.GetComponent<EnemyController>().StopMoveRight();
            other.gameObject.GetComponent<EnemyController>().StopJump();

        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            onPlatform0 = false;
            trigger.isTrigger0 = false;
            if((trigger.isTrigger0 == false) && (trigger.isTrigger1 == false) && (trigger.isTrigger2 == false))
            {
                trigger.isTrigger = false;
            }
        }
        else if(other.gameObject.tag == "Player_part1")
        {
            onPlatform1 = false;
            trigger.isTrigger1 = false;
            if((trigger.isTrigger0 == false) && (trigger.isTrigger1 == false) && (trigger.isTrigger2 == false))
            {
                trigger.isTrigger = false;
                trigger.functionNum = trigger.functionNum_default;
            }
        }
        else if(other.gameObject.tag == "Player_part2")
        {
            onPlatform2 = false;
            trigger.isTrigger2 = false;
            if((trigger.isTrigger0 == false) && (trigger.isTrigger1 == false) && (trigger.isTrigger2 == false))
            {
                trigger.isTrigger = false;
                trigger.functionNum = trigger.functionNum_default;
            }
        }
        else if(other.gameObject.tag == "Enemy")
        {
            onPlatform3 = false;

            other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
            other.gameObject.GetComponent<EnemyController>().StopMoveRight();
            //other.gameObject.GetComponent<EnemyController>().StopJump();
        }

    }  

    private void OnCollisionStay2D(Collision2D other)
    {

        // function control of two parts
        if(other.gameObject.tag == "Player_part1")
        {
            if(other.gameObject.GetComponent<Character1>().FunctionControl() != -1)
            {
                trigger.functionNum = other.gameObject.GetComponent<Character1>().FunctionControl();
            }
            else
            {
                trigger.functionNum = trigger.functionNum_default;
            }
        }
        if(other.gameObject.tag == "Player_part2")
        {
            if(other.gameObject.GetComponent<Character2>().FunctionControl() != -1)
            {
                trigger.functionNum = other.gameObject.GetComponent<Character2>().FunctionControl();
            }
            else
            {
                trigger.functionNum = trigger.functionNum_default;

            }
        }
        
        // function of enemy
        if(other.gameObject.tag == "Enemy" && trigger.isTrigger == true)
        {
            if(trigger.functionNum == 0)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
            }

            else if(trigger.functionNum == 1)
            {
                
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveLeft();
            }
            else if(trigger.functionNum == 2)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveRight();
            }
            else if(trigger.functionNum == 3)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().Jump();
            }
            else if(trigger.functionNum == 4)
            {
                other.gameObject.GetComponent<EnemyController>().Attach();
            }
        }
        else if(other.gameObject.tag == "Enemy" && trigger.isTrigger == false)
        {
            other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
            other.gameObject.GetComponent<EnemyController>().StopMoveRight();
            other.gameObject.GetComponent<EnemyController>().StopJump();
        }
    }  

    


}
