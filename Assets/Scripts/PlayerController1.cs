using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate() //constant check, for rigidbody
    {
        
        Movement();
        //SwitchAnim();
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal"); // float
        float faceDirection = Input.GetAxisRaw("Horizontal"); //-1, 0, 1
        if (horizontalMove != 0f)
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
        if (faceDirection != 0f)
        {
            transform.localScale = new Vector3(faceDirection * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // void SwitchAnim()
    // {
    //     if (anim.GetBool("jumping"))
    //     {
    //         if (rb.velocity.y < 0)
    //         {
    //             anim.SetBool("jumping", false);
    //             anim.SetBool("falling", true);
    //         }
    //     }
    //     else if(coll.IsTouchingLayers(ground))
    //     {
    //         anim.SetBool("falling", false);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
    }

    private void OnCollisionStay2D(Collision2D other) 
    {

    }


}
