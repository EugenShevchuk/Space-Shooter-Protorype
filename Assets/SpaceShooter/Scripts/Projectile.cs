using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Borderline borderline;
    [HideInInspector] public WeaponObject ProjectileType;

    private void Awake()
    {
        borderline = GetComponent<Borderline>();
    }

    private void Update()
    {
        if (borderline.offUp)
            Destroy(gameObject);
    }
}
