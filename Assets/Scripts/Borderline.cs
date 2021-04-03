using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borderline : MonoBehaviour
{
    public float radius = 1f;
    public bool keepOnScreen = true;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    public bool isOnscreen = true;
    public float camWidth;
    public float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        isOnscreen = true;
        offDown = offUp = offRight = offLeft = false;

        if (CompareTag("Enemy") || CompareTag("PlayerProjectile") || CompareTag("EnemyProjectile"))
            keepOnScreen = false;

        if (position.x > camWidth - radius) 
        {
            position.x = camWidth - radius;
            offRight = true;
        }

        if (position.x < radius - camWidth)
        {
            position.x = radius - camWidth;
            offLeft = true;
        }

        if (position.y > camHeight - radius)
        {
            position.y = camHeight - radius;
            offUp = true;
        }

        if (position.y < radius - camHeight)
        {
            position.y = radius - camHeight;
            offDown = true;
        }

        isOnscreen = !(offUp || offDown || offRight || offLeft);
        if (keepOnScreen && !isOnscreen)
        {
            transform.position = position;
            isOnscreen = true;
            offUp = offDown = offRight = offLeft = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Vector3 borders = new Vector3(camWidth * 2, camHeight * 2, 0.1f);

        Gizmos.DrawWireCube(Vector3.zero, borders);
    }
}
