using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 target;
    Animator anim;
    public GameObject bullet;
    public GameObject player;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            Move();
        }
        if(anim.enabled == false && active)
        {
            agent.isStopped = true;
            active = false;
            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);

        //add in item drop here
        Instantiate(bullet, this.transform.position, Quaternion.identity);
        
        Destroy(this.gameObject);
    }

    void Move()
    {
        if (player != null)
        {
            if (target != player.transform.position)
            {
                target = player.transform.position;
            }

            agent.SetDestination(target);

            anim.SetFloat("Speed", agent.speed);
        }
    }


}
