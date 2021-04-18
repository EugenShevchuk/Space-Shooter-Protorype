using UnityEngine;

public enum WeaponType
{
    Kinematic,
    Blaster,
    Laser
}

public class WeaponObject : BaseObject
{
    public WeaponType WeaponType;
    public GameObject ProjectilePrefab;
    public float DamageOnHit = 0;
    public float DamagePerSecond = 0;
    public float FireRate = 0;
    public float Velocity = 0;
    public int Level;

    private void Awake()
    {
        Type = ObjectType.Weapon;
    }
}
