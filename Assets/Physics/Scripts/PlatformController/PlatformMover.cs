using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public GameObject instruction;
    float limit = -6;
    bool moveUp = false;
    ConfigurableJoint joint;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        anim = GetComponent<Animator>();
        instruction = GameObject.FindGameObjectWithTag("Platform");
        instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("MoveUp", moveUp);
        if(moveUp)
        {
            instruction.SetActive(false); 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (InputMan.instance.CheckKeyDown("Interact"))
            {
                moveUp = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            instruction.SetActive(true);
            if(InputMan.instance.CheckKeyDown("Interact"))
            {
                moveUp = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            instruction.SetActive(false);
        }
    }
}
