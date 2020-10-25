using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   private enum CamStates
    {
        Normal,
        Pitfall,
        WallsidePlatforming,
        Fixed
    }
    public Vector3 offset;
    public float tempOffset = 0.5f;
    public float rotateSpeed;
    public bool useOffsetValues;
    public Transform target;
    public Transform pivot;
    //Vector3 bumperRayOffset;
    //float bumperDistanceCheck = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent   = target.transform ;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 wantedPosition = target.TransformPoint(0, 10, 3);
               
        if (!InputMan.instance.CheckKey("MouseGrab"))
        {
            //get x position of mouse and rotate target
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0, horizontal, 0);
        }
        else
        {
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            pivot.Rotate(0, horizontal, 0);
        }
        
        //get y position of mouse and rotate target
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * 5);

        float desiredYAngle;
        if (!InputMan.instance.CheckKey("MouseGrab"))
        {
            desiredYAngle = target.eulerAngles.y;
        }
        else
        {
            desiredYAngle = pivot.eulerAngles.y; 
        }

        //float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(0/*desiredXAngle*/, desiredYAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt((target.transform.position + new Vector3(0, 1.5f, 0)));
    }
}
