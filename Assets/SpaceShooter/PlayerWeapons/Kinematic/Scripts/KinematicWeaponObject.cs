using UnityEngine;

[CreateAssetMenu(fileName = "Kinematic", menuName = "ScriptableObjects/Weapons/Kinematic")]
public class KinematicWeaponObject : ScriptableObject
{
    public GameObject ProjectilePrefab;

    [Header("Base Stats")]
    public float DamageOnHit;
    public float FireRate;
    public float Velocity;    

    [Header("Bonuses for Upgrading")]    
    public float DamageOnHitBonus1_5 = 0.5f;
    public float DamageOnHitBonus5_10 = 1;
}
