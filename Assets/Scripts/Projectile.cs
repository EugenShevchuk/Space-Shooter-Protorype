using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Borderline _borderline;

    private void Awake()
    {
        _borderline = GetComponent<Borderline>();
    }

    private void Update()
    {
        if (_borderline.offUp)
            Destroy(gameObject);
    }
}
