using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link2 : MonoBehaviour
{
    public bool isRight;
    public float width;

    private LineRenderer lineRederer;

    private Transform platform;
    private Collider2D platform_coll;


    // Start is called before the first frame update
    void Start()
    {
        //isRight = true;
        lineRederer = GetComponent<LineRenderer>();
        lineRederer.enabled = true;
        lineRederer.positionCount = 2;
        lineRederer.startWidth = width;

        platform = GetComponentInParent<Transform>();
        platform_coll = GetComponentInParent<Collider2D>();

        //if (isRight)
        //{
        //    transform.position = new Vector3(platform.position.x + platform_coll.bounds.size.x / 2, platform.position.y, platform.position.z);
        //}
        //else
        //{
        //    transform.position = new Vector3(platform.position.x - platform_coll.bounds.size.x / 2, platform.position.y, platform.position.z);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit2D hit;

        if(isRight)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 10000, 1<<8);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 10000, 1<<8);
        }
        //Debug.DrawLine(transform.position, hit.point);
        //Debug.DrawRay(hit.point, Vector2.down, Color.red, 0.2f);

        lineRederer.SetPosition(0, transform.position);
        lineRederer.SetPosition(1, hit.point);
    }
}
