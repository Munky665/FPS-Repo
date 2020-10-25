using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float health;
    public float speed;
    public float jumpHeight;
    public float damage;
    public bool canJump;
}
