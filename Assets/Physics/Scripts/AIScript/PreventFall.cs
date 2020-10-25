using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PreventFall : MonoBehaviour
{
    float curruntY;
    // Start is called before the first frame update
    void Start()
    {
        curruntY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > curruntY)
        {
            transform.position = new Vector3(transform.position.x, curruntY, transform.position.z);
        }
    }
}
