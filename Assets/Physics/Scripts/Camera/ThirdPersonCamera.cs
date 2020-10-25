using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public GameObject target;
    private float targetDistance;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;
    float offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        targetDistance = Vector3.Distance(transform.position, target.transform.position);   
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        if (Mathf.Abs(transform.rotation.y) > 90)
        {
            offset = -offset;
        }
        else if(Mathf.Abs(transform.rotation.y) < 90)
        {
            offset = +offset;
        }

        //clamp vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        //rotate camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

  

        //move the camera position
        transform.position = (target.transform.position + new Vector3(offset,1.5f,0) ) - (transform.forward * targetDistance);


    }
}
