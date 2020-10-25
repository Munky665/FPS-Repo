using System.Collections;
using System.Threading;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxturnAngle = 90.0f;
    private float rotX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentState == States.PLAY)
        {
            MouseAiming();
            // KeyboardMovement();
        }
    }

    void MouseAiming()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        //clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxturnAngle);

        //rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    //void KeyboardMovement()
    //{
    //    Vector3 dir = new Vector3(0, 0, 0);

    //    dir.x = Input.GetAxis("Horizontal");
    //    dir.z = Input.GetAxis("Vertical");

    //    transform.Translate(dir * moveSpeed * Time.deltaTime);
    //}
}
