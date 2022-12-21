using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character1 : Character
{
    private Collider2D coll;

    public Sprite controlPic;
    public Sprite notControlPic;


    public override void Start()
    {
        coll = GetComponent<Collider2D>();
    }


    private void Update() 
    {
        Combine();
        SwitchControl();
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player_part2")
        {
            isCombine = true;
        }
        else if(other.gameObject.tag == "Enemy")
        {
            DeathCombine();
        }

    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Platform")
        {
            float scale_x = coll.bounds.size.x/2-0.15f;
            float scale_y = coll.bounds.size.y/ 2-0.15f;
            
            Vector3 pos1 = new Vector3(seperate1_transform.position.x-scale_x, seperate1_transform.position.y-scale_y, seperate1_transform.position.z);
            Vector3 pos2 = new Vector3(seperate1_transform.position.x+scale_x, seperate1_transform.position.y-scale_y, seperate1_transform.position.z);
            Vector3 pos3 = new Vector3(seperate1_transform.position.x-scale_x, seperate1_transform.position.y+scale_y, seperate1_transform.position.z);
            Vector3 pos4 = new Vector3(seperate1_transform.position.x+scale_x, seperate1_transform.position.y+scale_y, seperate1_transform.position.z);
            
            Debug.DrawRay(pos1, Vector3.down, Color.red, 0.05f);
            Debug.DrawRay(pos2, Vector3.down, Color.red, 0.05f);
            Debug.DrawRay(pos3, Vector3.up, Color.red, 0.05f);
            Debug.DrawRay(pos4, Vector3.up, Color.red, 0.05f);
            

            Bounds platformBounds = other.gameObject.GetComponent<Renderer>().bounds;
            if(platformBounds.Contains(pos1) | platformBounds.Contains(pos2) | platformBounds.Contains(pos3) | platformBounds.Contains(pos4))
            {
                DeathCombine();
                print("deathcombine");
            }
        }

        if(control != 1)
        {
            return;
        }
        else
        {
            if(other.gameObject.tag == "Trigger")
            {
                functionNum_control = other.gameObject.GetComponent<Trigger>().functionNum_default;                           
            }
            else if(other.gameObject.tag == "Platform")
            {
                functionNum_control = other.gameObject.GetComponentInParent<Trigger>().functionNum_default;            
            }
            //else if(other.gameObject.tag == "Ground")
            //{
            //    functionNum_control = 0;
            //} 
        }

        
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(control != 1)
        {
            return;
        }
        else
        {
            if(other.gameObject.tag == "Trigger" | other.gameObject.tag == "Platform" | other.gameObject.tag == "Ground")
            {
                    functionNum_control = -1;
            }
        }
    }
    
    void Combine()
    {
        if(control == 1 && isCombine)
        {
            control = 0;
            functionNum_control = -1;

            combine.SetActive(true);
            combine.GetComponent<PlayerController0>().enabled = true;
            combine_transform.position = new Vector3(seperate1_transform.position.x, seperate1_transform.position.y+seperate1_transform.localScale.y/2-0.1f, seperate1_transform.position.z);

            seperate1.SetActive(false);
            seperate2.SetActive(false);

        }
    }

    void SwitchControl()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            if(control == 1)
            {
                control = 2;
                seperate1.GetComponent<PlayerController1>().enabled = false;
                seperate2.GetComponent<PlayerController1>().enabled = true;

                seperate1.GetComponent<SpriteRenderer>().sprite = notControlPic;
                seperate2.GetComponent<SpriteRenderer>().sprite = controlPic;
            }
            else
            {
                control = 1;
                seperate1.GetComponent<PlayerController1>().enabled = true;
                seperate2.GetComponent<PlayerController1>().enabled = false;

                seperate1.GetComponent<SpriteRenderer>().sprite = controlPic;
                seperate2.GetComponent<SpriteRenderer>().sprite = notControlPic;
            }
        }
    }

    public void DeathCombine()
    {
        control = 0;
        functionNum_control = -1;

        combine.SetActive(true);
        combine.GetComponent<PlayerController0>().enabled = true;
        combine_transform.position = new Vector3(seperate2_transform.position.x, seperate2_transform.position.y+seperate2_transform.localScale.y/2-0.1f, seperate2_transform.position.z);

        seperate1.SetActive(false);
        seperate2.SetActive(false);
    }

    public int FunctionControl()
    {
        return functionNum_control;
    }


    
}
