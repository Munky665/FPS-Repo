using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayFootstep : MonoBehaviour
{
    AudioSource source;
    bool step = false;
    float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(GetComponent<AgentMove>().active && timer < 0)
        {
            source.clip = AudioMan.instance.sneakingManiquin;
            source.Play();
            timer = 2;
        }
    }

}
