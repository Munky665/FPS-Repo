using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{

    public AudioClip gunShot;
    public AudioClip enemyDamage;
    public AudioClip sneakingManiquin;
    public AudioClip grenadeExplosion;

    Dictionary<string, AudioClip> audioFiles;

    public static AudioMan instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetAudio(string key)
    {
 
        switch (key)
        {
            case "GunFire":
                return gunShot;
            case "footStep":
                return sneakingManiquin;
            case "EnemyDamage":
                return enemyDamage;
            case "Grenade":
                return grenadeExplosion;
            default:
                return null;
        }
    }
}
