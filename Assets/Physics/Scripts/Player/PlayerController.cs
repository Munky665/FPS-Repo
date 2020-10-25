using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CharacterController))]
//[RequireComponent (typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    CharacterController controller = null;
    Animator animator = null;
    public Text grenadeCount;
    public Text ammoCount;
    public GameObject grenadePrefab;
    public Light gunFlash;
    public float throwForce = 10;
    public float speed;
    public float pushPower = 2.0f;
    public float range = 50.0f;
    public float numberOfGrenades = 3;
    public float ammo = 24;
    public int ammoDrop;
    AudioSource source;
    public AudioSource sourceTwo;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        grenadeCount = GameObject.FindGameObjectWithTag("Grenade").GetComponent<Text>();
        ammoCount = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentState == States.PLAY)
        {
            Move();
            if (ammo > 0)
            {
                FireGunCheck();
            }
            ThrowGrenadeCheck();
            UpdateAmmo();
            
        }
    }

    void UpdateAmmo()
    {
        grenadeCount.text = numberOfGrenades.ToString();
        ammoCount.text = ammo.ToString();
    }

    void ThrowGrenadeCheck()
    {
        if (InputMan.instance.CheckKeyDown("Grenade") && numberOfGrenades > 0)
        {
            GameObject gren = Instantiate(grenadePrefab, (transform.position + new Vector3(0,0.25f,0)) + transform.forward, transform.rotation);

            gren.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
            numberOfGrenades--;
        }
    }

    void FireGunCheck()
    {

        if (InputMan.instance.CheckKeyDown("Attack"))
        {
            source.clip = AudioMan.instance.GetAudio("GunFire");
            source.Play();
            StartCoroutine(GunFlash());
            ammo--;
            if (Physics.Raycast(transform.position + transform.forward * 0.5f, transform.forward, out RaycastHit hit, range))
            {
                Debug.DrawRay(transform.position + transform.forward * 2, transform.forward * range, Color.yellow, 5);
                if (hit.collider.gameObject.tag == "Enemy" && hit.collider.gameObject.GetComponentInParent< AgentMove>().active)
                {
                    hit.collider.gameObject.GetComponentInParent<Animator>().enabled = false;

                    sourceTwo.clip = AudioMan.instance.GetAudio("EnemyDamage");
                    sourceTwo.PlayDelayed(0.25f);
                }
            }
        }
    }

    IEnumerator GunFlash()
    {
        gunFlash.enabled = true;
        yield return new WaitForSeconds(0.05f);
        gunFlash.enabled = false;
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float turn = Input.GetAxis("Mouse X");

        var moveVec = Vector3.Normalize((transform.forward * vertical) + (transform.right * horizontal));

        if (InputMan.instance.CheckKey("Sprint"))
        {
            var temp = speed * 2;
            controller.SimpleMove(moveVec * temp /** Time.deltaTime*/);
        }
        else
        {
            controller.SimpleMove(moveVec * speed /** Time.deltaTime*/);
        }


        transform.Rotate(transform.up, turn * speed * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if(body == null || body.isKinematic)
        {
            return;
        }    
        if(hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;

        if (hit.gameObject.tag == "Enemy" && hit.gameObject.GetComponentInParent<AgentMove>().active)
        {
            GameManager.instance.currentState = States.GAMEOVER;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            Ammo();
            Destroy(other.gameObject);
        }
    }

    void Ammo()
    {
        ammo += ammoDrop;
    }
}
