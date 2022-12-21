using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public int direction;
    public float width;
    private LineRenderer lineRenderer;

    private Trigger trigger;
    //[SerializeField]
    private bool isTrigger;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = width;
        lineRenderer.useWorldSpace = true;

        trigger = GetComponentInParent<Trigger>();
        isTrigger = false;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isTrigger = trigger.isTrigger;
        Shoot();
    }

    void Shoot()
    {
        RaycastHit2D hit0;
        RaycastHit2D hit1;
        RaycastHit2D hit2;
        RaycastHit2D hit;
        Vector3 hitPos;

        if(isTrigger)
        {
            lineRenderer.enabled = true;
            if (direction == 0)
            {
                hit0 = Physics2D.Raycast(transform.position, Vector2.up, 10000, (1<<7)|(1<<8)|(1<<9)|(1<<10));
                hit1 = Physics2D.Raycast(transform.position - new Vector3(width / 2, 0, 0), Vector2.up, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                hit2 = Physics2D.Raycast(transform.position + new Vector3(width / 2, 0, 0), Vector2.up, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                
                if (hit0.point.y <= hit1.point.y && hit0.point.y <= hit2.point.y)
                {
                    hit = hit0;
                }
                else if (hit1.point.y <= hit0.point.y && hit1.point.y <= hit0.point.y)
                {
                    hit = hit1;
                }
                else
                {
                    hit = hit2;
                }
                hitPos = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
            else if (direction == 1)
            {
                hit0 = Physics2D.Raycast(transform.position, Vector2.down, 10000, (1<<7)|(1<<8)|(1<<9)|(1<<10));
                hit1 = Physics2D.Raycast(transform.position - new Vector3(width / 2, 0, 0), Vector2.down, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                hit2 = Physics2D.Raycast(transform.position + new Vector3(width / 2, 0, 0), Vector2.down, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                if (hit0.point.y >= hit1.point.y && hit0.point.y >= hit2.point.y)
                {
                    hit = hit0;
                }
                else if (hit1.point.y >= hit0.point.y && hit1.point.y >= hit0.point.y)
                {
                    hit = hit1;
                }
                else
                {
                    hit = hit2;
                }
                hitPos = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
            else if (direction == 2)
            {
                hit0 = Physics2D.Raycast(transform.position, Vector2.left, 10000, (1<<7)|(1<<8)|(1<<9)|(1<<10));
                hit1 = Physics2D.Raycast(transform.position - new Vector3(0, width / 2, 0), Vector2.left, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                hit2 = Physics2D.Raycast(transform.position + new Vector3(0, width / 2, 0), Vector2.left, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                if (hit0.point.x >= hit1.point.x && hit0.point.x >= hit2.point.x)
                {
                    hit = hit0;
                }
                else if (hit1.point.x >= hit0.point.x && hit1.point.x >= hit0.point.x)
                {
                    hit = hit1;
                }
                else
                {
                    hit = hit2;
                }
                hitPos = new Vector3(hit.point.x, transform.position.y, transform.position.z);
            }
            else
            {
                hit0 = Physics2D.Raycast(transform.position, Vector2.right, 10000, (1<<7)|(1<<8)|(1<<9)|(1<<10));
                hit1 = Physics2D.Raycast(transform.position - new Vector3(0, width / 2, 0), Vector2.right, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                hit2 = Physics2D.Raycast(transform.position + new Vector3(0, width / 2, 0), Vector2.right, 10000, (1 << 7) | (1 << 8) | (1 << 9) | (1 << 10));
                if (hit0.point.x <= hit1.point.x && hit0.point.x <= hit2.point.x)
                {
                    hit = hit0;
                }
                else if (hit1.point.x <= hit0.point.x && hit1.point.x <= hit0.point.x)
                {
                    hit = hit1;
                }
                else
                {
                    hit = hit2;
                }
                hitPos = new Vector3(hit.point.x, transform.position.y, transform.position.z);
            }

            if (hit0)
            {
                if(hit0.collider.tag == "Player")
                {
                    hit0.collider.GetComponent<Character0>().Death();
                }
                else if (hit0.collider.tag == "Player_part1")
                {
                    hit0.collider.GetComponent<Character1>().DeathCombine();
                }
                else if (hit0.collider.tag == "Player_part2")
                {
                    hit0.collider.GetComponent<Character2>().DeathCombine();
                }
                else if (hit0.collider.tag == "Enemy")
                {
                    hit0.collider.GetComponent<EnemyController>().Death();
                }
            }
            if (hit1)
            {
                if (hit1.collider.tag == "Player")
                {
                    hit1.collider.GetComponent<Character0>().Death();
                }
                else if (hit1.collider.tag == "Player_part1")
                {
                    hit1.collider.GetComponent<Character1>().DeathCombine();
                }
                else if (hit1.collider.tag == "Player_part2")
                {
                    hit1.collider.GetComponent<Character2>().DeathCombine();
                }
                else if (hit1.collider.tag == "Enemy")
                {
                    hit1.collider.GetComponent<EnemyController>().Death();
                }
            }
            if (hit2)
            {
                if (hit2.collider.tag == "Player")
                {
                    hit2.collider.GetComponent<Character0>().Death();
                }
                else if (hit2.collider.tag == "Player_part1")
                {
                    hit2.collider.GetComponent<Character1>().DeathCombine();
                }
                else if (hit2.collider.tag == "Player_part2")
                {
                    hit2.collider.GetComponent<Character2>().DeathCombine();
                }
                else if (hit2.collider.tag == "Enemy")
                {
                    hit2.collider.GetComponent<EnemyController>().Death();
                }
            }

            Debug.DrawRay(new Vector3(transform.position.x - lineRenderer.bounds.size.x/2, transform.position.y, transform.position.z), Vector2.up, Color.green);

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hitPos);
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }
}
