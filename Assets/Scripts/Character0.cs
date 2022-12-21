using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character0 : Character
{

    private Collider2D coll;

    public float shootforce;
    public LineRenderer direction_UI;
    private bool isChoosing;
    private int direction;

    
    public override void Start() 
    {
        base.Start();

        coll = GetComponent<Collider2D>();

        isChoosing = false;
        direction = 0;  //-1: left, 0: up, 1: right
    }


    private void Update() 
    {
        Seperate();
    }



    void Seperate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            direction_UI.enabled = true;
            isCombine = false;

            isChoosing = true;
            direction = 0;

            combine.GetComponent<PlayerController0>().enabled = false;
        }

        if (isChoosing)
        {

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                direction = -1;
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                direction = 1;
            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                direction = 0;
            }

            if (direction == -1)
            {
                direction_UI.SetPosition(0, new Vector3(combine_transform.position.x-2, combine_transform.position.y, combine_transform.position.y));
                direction_UI.SetPosition(1, new Vector3(combine_transform.position.x-1, combine_transform.position.y, combine_transform.position.y));
            }
            else if(direction == 1)
            {
                direction_UI.SetPosition(0, new Vector3(combine_transform.position.x+2, combine_transform.position.y, combine_transform.position.y));
                direction_UI.SetPosition(1, new Vector3(combine_transform.position.x+1, combine_transform.position.y, combine_transform.position.y));
            }
            else
            {
                direction_UI.SetPosition(0, new Vector3(combine_transform.position.x, combine_transform.position.y+2, combine_transform.position.y));
                direction_UI.SetPosition(1, new Vector3(combine_transform.position.x, combine_transform.position.y+1, combine_transform.position.y));
            }

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            control = 1;
            seperate1.SetActive(true);
            seperate1_transform.position = new Vector3(combine_transform.position.x, combine_transform.position.y-combine_transform.localScale.y/4-0.1f, combine_transform.position.z);
            seperate1.GetComponent<PlayerController1>().enabled = true;

            seperate2.SetActive(true);
            seperate2_transform.position = new Vector3(combine_transform.position.x, combine_transform.position.y+combine_transform.localScale.y/4+0.1f, combine_transform.position.z);
            seperate2.GetComponent<PlayerController1>().enabled = false;
            

            isShooting = true;

            if (direction == -1)
            {
                seperate2_rb.velocity = new Vector2(-shootforce, 0);
            }
            else if(direction == 1)
            {  
                seperate2_rb.velocity = new Vector2(shootforce, 0);
            }
            else
            {
                seperate2_rb.velocity = new Vector2(0, shootforce);        
            }
            isChoosing = false;
            direction_UI.enabled = false;


            combine.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Platform")
        {
            float scale_x = coll.bounds.size.x/2-0.1f;
            float scale_y = coll.bounds.size.y/2-0.1f;
            
            Vector3 pos1 = new Vector3(combine_transform.position.x-scale_x, combine_transform.position.y-scale_y, combine_transform.position.z);
            Vector3 pos2 = new Vector3(combine_transform.position.x+scale_x, combine_transform.position.y-scale_y, combine_transform.position.z);
            Vector3 pos3 = new Vector3(combine_transform.position.x-scale_x, combine_transform.position.y+scale_y, combine_transform.position.z);
            Vector3 pos4 = new Vector3(combine_transform.position.x+scale_x, combine_transform.position.y+scale_y, combine_transform.position.z);
            Vector3 pos5 = new Vector3(combine_transform.position.x-scale_x, combine_transform.position.y, combine_transform.position.z);
            Vector3 pos6 = new Vector3(combine_transform.position.x+scale_x, combine_transform.position.y, combine_transform.position.z);
            Vector3 pos7 = new Vector3(combine_transform.position.x, combine_transform.position.y+scale_y, combine_transform.position.z);
            Vector3 pos8 = new Vector3(combine_transform.position.x, combine_transform.position.y-scale_y, combine_transform.position.z);
            Debug.DrawLine(pos1, pos2, Color.red);
            Debug.DrawLine(pos7, pos8, Color.blue);



            
            Bounds platformBounds = other.gameObject.GetComponent<Renderer>().bounds;
            if(platformBounds.Contains(pos1) | platformBounds.Contains(pos2) | platformBounds.Contains(pos3) | platformBounds.Contains(pos4) |
                platformBounds.Contains(pos5) | platformBounds.Contains(pos6) | platformBounds.Contains(pos7) | platformBounds.Contains(pos8))
            {
                Death();
                print("death");
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Death();
        }
        
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
