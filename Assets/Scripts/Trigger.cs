using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Trigger : MonoBehaviour
{
    public int functionNum_default;
    public int functionNum; //0: no functionNum, 1: moveleft, 2:moveright, 3:jump, 4: attach

    public bool isTrigger;
    public bool isTrigger0;
    public bool isTrigger1;
    public bool isTrigger2;

    public Text functionName;
    public Image functionPic;
    //public GameObject functionUI;

    public Sprite moveLeftPic;
    public Sprite moveRightPic;
    public Sprite jumpPic;

    //public Material lightMeterial;
    //public Material normalMeterial;

    // Start is called before the first frame update
    void Start()
    {
        functionNum = functionNum_default;
        //normalMeterial = functionPic.material;
    }

    // Update is called once per frame
    void Update()
    {
        Show();
    }

    private void Show()
    {
        try
        {
            functionName.enabled = false;

            if (functionNum == 0)
            {
                functionName.text = "";
                functionPic.enabled = false;
            }
            else if (functionNum == 1)
            {
                functionName.text = "MoveLeft";
                functionPic.enabled = true;
                functionPic.sprite = moveLeftPic;
            }
            else if (functionNum == 2)
            {
                functionName.text = "MoveRight";
                functionPic.enabled = true;
                functionPic.sprite = moveRightPic;
            }
            else if (functionNum == 3)
            {
                functionName.text = "Jump";
                functionPic.enabled = true;
                functionPic.sprite = jumpPic;
            }
            else if (functionNum == 4)
            {
                functionName.text = "Attach";
            }

            if (isTrigger)
            {
                functionName.color = Color.red;
                //functionPic.material = lightMeterial;
            }
            else
            {
                functionName.color = Color.green;
                //functionPic.material = normalMeterial;
            }
        }
        catch (NullReferenceException ex)
        {

        }

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isTrigger = true;
            isTrigger0 = true;
        }
        else if(other.gameObject.tag == "Player_part1")
        {
            isTrigger = true;
            isTrigger1 = true;
        }
        else if(other.gameObject.tag == "Player_part2")
        {
            isTrigger = true;
            isTrigger2 = true;
        }
        else if (other.gameObject.tag == "Enemy" && isTrigger == true)
        {
            if (functionNum == 0)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
            }

            else if (functionNum == 1)
            {

                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveLeft();
            }
            else if (functionNum == 2)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveRight();
            }
            else if (functionNum == 3)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().Jump();
            }
        }
        else if (other.gameObject.tag == "Enemy" && isTrigger == false)
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
            isTrigger0 = false;
            if((isTrigger1 == false) && (isTrigger1 == false) && (isTrigger2 == false))
            {
                isTrigger = false;
            }
        }
        else if(other.gameObject.tag == "Player_part1")
        {
            isTrigger1 = false;
            if((isTrigger1 == false) && (isTrigger1 == false) && (isTrigger2 == false))
            {
                isTrigger = false;
                functionNum = functionNum_default;
            }
        }
        else if(other.gameObject.tag == "Player_part2")
        {
            isTrigger2 = false;
            if((isTrigger1 == false) && (isTrigger1 == false) && (isTrigger2 == false))
            {
                isTrigger = false;
                functionNum = functionNum_default;
            }
        }
        else if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
            other.gameObject.GetComponent<EnemyController>().StopMoveRight();
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {     
        if(other.gameObject.tag == "Player_part1")
        {
            if(other.gameObject.GetComponent<Character1>().FunctionControl() != -1)
            {
                functionNum = other.gameObject.GetComponent<Character1>().FunctionControl();
            }
            else
            {
                functionNum = functionNum_default;
            }
        }
        if(other.gameObject.tag == "Player_part2")
        {
            if(other.gameObject.GetComponent<Character2>().FunctionControl() != -1)
            {
                functionNum = other.gameObject.GetComponent<Character2>().FunctionControl();
            }
            else
            {
                functionNum = functionNum_default;
            }
        }        
        if(other.gameObject.tag == "Enemy" && isTrigger == true)
        {
            if(functionNum == 0)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
            }

            else if(functionNum == 1)
            {
                
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveLeft();
            }
            else if(functionNum == 2)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopJump();
                other.gameObject.GetComponent<EnemyController>().MoveRight();
            }
            else if(functionNum == 3)
            {
                other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
                other.gameObject.GetComponent<EnemyController>().StopMoveRight();
                other.gameObject.GetComponent<EnemyController>().Jump();
            }
        }
        else if(other.gameObject.tag == "Enemy" && isTrigger == false)
        {
            other.gameObject.GetComponent<EnemyController>().StopMoveLeft();
            other.gameObject.GetComponent<EnemyController>().StopMoveRight();
            other.gameObject.GetComponent<EnemyController>().StopJump();
        }
        
    }

}
