using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2 : Character
{
    private float gravity;

    private Collider2D coll;

    public override void Start()
    {
        coll = GetComponent<Collider2D>();
    }


    private void Update() 
    {
        Combine();
        //SwitchControl();
        Shooting();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player_part1")
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
            float scale_y = coll.bounds.size.y/2-0.15f;
            
            Vector3 pos1 = new Vector3(seperate2_transform.position.x-scale_x, seperate2_transform.position.y-scale_y, seperate2_transform.position.z);
            Vector3 pos2 = new Vector3(seperate2_transform.position.x+scale_x, seperate2_transform.position.y-scale_y, seperate2_transform.position.z);
            Vector3 pos3 = new Vector3(seperate2_transform.position.x-scale_x, seperate2_transform.position.y+scale_y, seperate2_transform.position.z);
            Vector3 pos4 = new Vector3(seperate2_transform.position.x+scale_x, seperate2_transform.position.y+scale_y, seperate2_transform.position.z);
            Debug.DrawRay(pos1, Vector3.down, Color.red, 0.05f);
            Debug.DrawRay(pos2, Vector3.down, Color.red, 0.05f);
            Debug.DrawRay(pos3, Vector3.up, Color.red, 0.05f);
            Debug.DrawRay(pos4, Vector3.up, Color.red, 0.05f);

            Bounds platformBounds = other.gameObject.GetComponent<Renderer>().bounds;
            if(platformBounds.Contains(pos1) | platformBounds.Contains(pos2) | platformBounds.Contains(pos3) | platformBounds.Contains(pos4))
            {
                DeathCombine();
            }
        }

        if(control != 2)
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
            //else if (other.gameObject.tag == "Ground")
            //{
            //    functionNum_control = 0;
            //}
        }

    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(control != 2)
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
        if(control == 2 && isCombine)
        {
            control = 0;
            functionNum_control = -1;

            combine.SetActive(true);
            combine.GetComponent<PlayerController0>().enabled = true;
            combine_transform.position = new Vector3(seperate2_transform.position.x, seperate2_transform.position.y+seperate2_transform.localScale.y/2-0.1f, seperate2_transform.position.z);

            seperate1.SetActive(false);
            seperate2.SetActive(false);

        }
    }

    void SwitchControl()
    {
        if(Input.GetButton("Fire3"))
        {
            if(control == 1)
            {
                control = 2;
                seperate1.GetComponent<PlayerController1>().enabled = false;
                seperate2.GetComponent<PlayerController1>().enabled = true;
            }
            else
            {
                control = 1;
                seperate1.GetComponent<PlayerController1>().enabled = true;
                seperate2.GetComponent<PlayerController1>().enabled = false;
            }
        }
    }

    public void DeathCombine()
    {
        control = 0;
        functionNum_control = -1;

        combine.SetActive(true);
        combine.GetComponent<PlayerController0>().enabled = true;
        combine_transform.position = new Vector3(seperate1_transform.position.x, seperate1_transform.position.y+seperate1_transform.localScale.y/2-0.1f, seperate1_transform.position.z);

        seperate1.SetActive(false);
        seperate2.SetActive(false);
    }

    public void Shooting()
    {
        if(Mathf.Abs(seperate2_rb.velocity.x) < 1.0f && Mathf.Abs(seperate2_rb.velocity.y) < 1.0f)
        {
            isShooting = false;
        }

        if(isShooting)
        {
            if(seperate2_rb.gravityScale != 0f)
            {
                gravity = seperate2_rb.gravityScale;
            }

            seperate2_rb.gravityScale = 0;
            
            if(control == 2)
            {
                control = 1;
                seperate1.GetComponent<PlayerController1>().enabled = true;
                seperate2.GetComponent<PlayerController1>().enabled = false;
            
            }
            
        }
        else
        {
            seperate2_rb.gravityScale = gravity;
        }
    }

    public int FunctionControl()
    {
        return functionNum_control;
    }

}
