using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform1 : MonoBehaviour
{
    public bool back;
    public Transform top, bottom;
    private float topLine, bottomLine;

    public float goSpeed;
    public float backSpeed;
    private Trigger trigger;

    //[SerializeField]
    private bool onPlatform0;
    //[SerializeField]
    private bool onPlatform1;
    //[SerializeField]
    private bool onPlatform2;
    //[SerializeField]
    private bool onPlatform3;


    public Transform character;
    public Transform character1;
    public Transform character2;
    public Transform enemy;

    public Sprite backPic;
    public Sprite notBackPic;
    private SpriteRenderer spriteRenderer;

    //public Material lighting;
    //private Material normal;
    //private Renderer rend;



    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponentInParent<Trigger>();
        
        bottom.position = transform.position;

        topLine = top.position.y;
        bottomLine = bottom.position.y;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (back)
        {
            spriteRenderer.sprite = backPic;
        }
        else
        {
            spriteRenderer.sprite = notBackPic;
        }

        if(topLine < bottomLine)
        {
            spriteRenderer.flipY = true;
        }

        //rend = GetComponent<Renderer>();
        //normal = rend.material;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Movement();
    }

    void Movement() // bottom to top
    {
        if (trigger.isTrigger)
        {
            //rend.material = lighting;
            if (topLine > bottomLine)
            {
                if (transform.position.y <= topLine)
                {
                    float y = transform.position.y + goSpeed * Time.fixedDeltaTime;
                    transform.position = new Vector3(transform.position.x, y, transform.position.z);

                    if(onPlatform0)
                    {
                        character.position = new Vector3(character.position.x, character.position.y + goSpeed * Time.fixedDeltaTime, character.position.z);
                        //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                        //rb.velocity = rb.velocity-speed;
                    }
                    if(onPlatform1)
                    {
                        character1.position = new Vector3(character1.position.x, character1.position.y + goSpeed * Time.fixedDeltaTime, character1.position.z);
                    }
                    if(onPlatform2)
                    {
                        character2.position = new Vector3(character2.position.x, character2.position.y + goSpeed * Time.fixedDeltaTime, character2.position.z);
                    }
                    if(onPlatform3)
                    {

                        enemy.position = new Vector3(enemy.position.x, enemy.position.y + goSpeed * Time.fixedDeltaTime, enemy.position.z);
                    }


                }
            }
            else
            {
                if (transform.position.y >= topLine)
                {
                    float y = transform.position.y - goSpeed * Time.fixedDeltaTime;
                    transform.position = new Vector3(transform.position.x, y, transform.position.z);

                    if(onPlatform0)
                    {
                        character.position = new Vector3(character.position.x, character.position.y - goSpeed * Time.fixedDeltaTime, character.position.z);
                        //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                        //rb.velocity = rb.velocity-speed;
                    }
                    if(onPlatform1)
                    {
                        character1.position = new Vector3(character1.position.x, character1.position.y - goSpeed * Time.fixedDeltaTime, character1.position.z);
                    }
                    if(onPlatform2)
                    {
                        character2.position = new Vector3(character2.position.x, character2.position.y - goSpeed * Time.fixedDeltaTime, character2.position.z);
                    }
                    if(onPlatform3)
                    {

                        enemy.position = new Vector3(enemy.position.x, enemy.position.y - goSpeed * Time.fixedDeltaTime, enemy.position.z);
                    }

                }
            }
        }
        else
        {
            //rend.material = normal;
            if (back)
            {
                if (topLine > bottomLine)
                {
                    if (transform.position.y >= bottomLine)
                    {
                        float y = transform.position.y - backSpeed * Time.fixedDeltaTime;
                        transform.position = new Vector3(transform.position.x, y, transform.position.z);

                        if(onPlatform0)
                        {
                            character.position = new Vector3(character.position.x, character.position.y - backSpeed * Time.fixedDeltaTime, character.position.z);
                            //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                            //rb.velocity = rb.velocity-speed;
                        }
                        if(onPlatform1)
                        {
                            character1.position = new Vector3(character1.position.x, character1.position.y - backSpeed * Time.fixedDeltaTime, character1.position.z);
                        }
                        if(onPlatform2)
                        {
                            character2.position = new Vector3(character2.position.x, character2.position.y - backSpeed * Time.fixedDeltaTime, character2.position.z);
                        }

                        if(onPlatform3)
                        {
                            enemy.position = new Vector3(enemy.position.x, enemy.position.y - backSpeed * Time.fixedDeltaTime, enemy.position.z);
                        }
                    }
                }
                else
                {
                    if (transform.position.y <= bottomLine)
                    {
                        float y = transform.position.y + backSpeed * Time.fixedDeltaTime;
                        transform.position = new Vector3(transform.position.x, y, transform.position.z);

                        if(onPlatform0)
                        {
                            character.position = new Vector3(character.position.x, character.position.y + backSpeed * Time.fixedDeltaTime, character.position.z);
                            //rb.MovePosition(rb.position - speed * Time.fixedDeltaTime);
                            //rb.velocity = rb.velocity-speed;
                        }
                        if(onPlatform1)
                        {
                            character1.position = new Vector3(character1.position.x, character1.position.y + backSpeed * Time.fixedDeltaTime, character1.position.z);
                        }
                        if(onPlatform2)
                        {
                            character2.position = new Vector3(character2.position.x, character2.position.y + backSpeed * Time.fixedDeltaTime, character2.position.z);
                        }

                        if(onPlatform3)
                        {
                            enemy.position = new Vector3(enemy.position.x, enemy.position.y + backSpeed * Time.fixedDeltaTime, enemy.position.z);
                        }
                    }
                }
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
