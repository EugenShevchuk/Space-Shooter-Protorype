using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Borderline borderline;
    [HideInInspector] public float damageOnHit;


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
