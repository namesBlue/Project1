using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public static int control;

    public static bool isCombine;
    public static bool isShooting;

    public static int functionNum_control;

    //public static Collider2D map;


    public static GameObject combine;
    public static GameObject seperate1;
    public static GameObject seperate2;
    public static Transform combine_transform;
    public static Transform seperate1_transform;
    public static Transform seperate2_transform;

    public static Rigidbody2D seperate2_rb;

    // Start is called before the first frame update
    public virtual void Start()
    {
        control = 0;
        isCombine = true;
        isShooting = false;
        functionNum_control = -1;

        //map = GameObject.Find("Tilemap").GetComponent<Collider2D>();

        if (GameObject.Find("Character"))
        {
            combine = GameObject.Find("Character");
            combine_transform = combine.GetComponent<Transform>();  
        }

        if (GameObject.Find("Character1"))
        {
            seperate1 = GameObject.Find("Character1");
            seperate1_transform = seperate1.GetComponent<Transform>();
            seperate1.SetActive(false);

        }

        if (GameObject.Find("Character2"))
        {
            seperate2 = GameObject.Find("Character2");
            seperate2_transform = seperate2.GetComponent<Transform>();
            seperate2_rb = seperate2.GetComponent<Rigidbody2D>();
            seperate2.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
