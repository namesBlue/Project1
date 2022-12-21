using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link1 : MonoBehaviour
{
    public bool isDown;
    public float width;

    private LineRenderer lineRederer;

    private Transform platform;
    private Collider2D platform_coll;


    // Start is called before the first frame update
    void Start()
    {
        //isDown = true;
        lineRederer = GetComponent<LineRenderer>();
        lineRederer.enabled = true;
        lineRederer.positionCount = 2;
        lineRederer.startWidth = width;

        platform = GetComponentInParent<Transform>();
        platform_coll = GetComponentInParent<Collider2D>();

        //if (isDown)
        //{
        //    transform.position = new Vector3(platform.position.x, platform.position.y - platform_coll.bounds.size.y / 2, platform.position.z);
        //}
        //else
        //{
        //    transform.position = new Vector3(platform.position.x, platform.position.y + platform_coll.bounds.size.y / 2, platform.position.z);
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

        if(isDown)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 10000, 1<<8);
        }
        else
        {

            hit = Physics2D.Raycast(transform.position, Vector2.up, 10000, 1<<8);
        }
        Debug.DrawLine(transform.position, hit.point, Color.red);

        lineRederer.SetPosition(0, transform.position);
        lineRederer.SetPosition(1, hit.point);

    }
}
