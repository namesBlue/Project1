using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Camera : Character
// {
//     public Camera cameraOne;
//     public Camera cameraTwo;

//     private Vector3 pos;
//     private Vector3 inArea;

//     // private Bounds bounds;
//     // public Collider2D area;

//     public Transform target;
//     Camera cam;

//     // Start is called before the first frame update
//     public override void Start()
//     {
//         cam = GetComponent<Camera>();

//         cameraOne.enabled = true;
//         cameraTwo.enabled = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         SwitchCamera();
//     }

//     void SwitchCamera()
//     {
//         if(control == 0)
//         {
//             pos = combine_transform.position;
//         }
//         else if(control == 1)
//         {
//             pos = seperate1_transform.position;
//         }
//         else if(control == 2)
//         {
//             pos = seperate2_transform.position;
//         }

//         //inArea = bounds.Contains(pos);
//         inArea = cameraOne.WorldToViewportPoint(pos);

//         if(inArea.x >= 0 && inArea.x <= 1 && inArea.y >= 0 && inArea.y <= 1)
//         {
//             cameraOne.enabled = false;
//             cameraTwo.enabled = true;
//         }
//         else
//         {
//             cameraOne.enabled = true;
//             cameraTwo.enabled = false;
//         }
//     }

//     // void SwitchCamera()
//     // {
        
//     //     if(inArea)
//     //     {
//     //         cameraOne.enabled = true;
//     //         cameraTwo.enabled = false;
//     //     }
//     //     else
//     //     {
//     //         cameraOne.enabled = false;
//     //         cameraTwo.enabled = true;
//     //     }
//     // }

//     // private void OnBecameVisible() 
//     // {
//     //     inArea = true;
//     // }
//     // private void OnBecameInvisible() 
//     // {
//     //     inArea = false;
//     // }
// }

public class CameraController : Character
{
    public Camera cam0;
    public Camera cam1;
    private Vector3 pos;
    private Vector3 inArea;

    public override void Start()
    {
        cam0.enabled = true;
        cam1.enabled = false;
    }

    void Update()
    {
        if(control == 0)
        {
            pos = combine_transform.position;
        }
        else if(control == 1)
        {
            pos = seperate1_transform.position;
        }
        else if(control == 2)
        {
            pos = seperate2_transform.position;
        }

        //inArea = bounds.Contains(pos);
        inArea = cam0.WorldToViewportPoint(pos);

        if(inArea.x >= 0 && inArea.x <= 1 && inArea.y >= 0 && inArea.y <= 1)
        {
            cam0.enabled = true;
            cam1.enabled = false;
        }
        else
        {
            cam0.enabled = false;
            cam1.enabled = true;
        }
    }
}
