using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stopper")
        {
            JointMotor motor = new JointMotor();
            motor.force = 0;
            motor.targetVelocity = 0;
            GetComponent<HingeJoint>().motor = motor;
        }
    }
}
