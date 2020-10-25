using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public float timer = 2;
    float countdown;
    float force = 1000;
    bool hasExploded;
    public float radius = 3;
    public GameObject particles;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            GoBoom();
        }
    }

    void GoBoom()
    {
        Collider[] objectsEffected = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in objectsEffected)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if(rb != null)
            {
                if(c.gameObject.tag == "Enemy")
                {
                    c.gameObject.GetComponentInParent<Animator>().enabled = false;
                }
               
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        _ = Instantiate(particles, transform.position, transform.rotation);
        hasExploded = true;
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        source.clip = AudioMan.instance.GetAudio("Grenade");
        source.Play();
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
