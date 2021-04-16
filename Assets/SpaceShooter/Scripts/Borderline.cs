using UnityEngine;

public class Borderline : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private bool keepOnScreen = true;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    [SerializeField] private bool isOnscreen = true;
    public float CamWidth;
    public float CamHeight;

    private void Awake()
    {
        CamHeight = Camera.main.orthographicSize;
        CamWidth = CamHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        isOnscreen = true;
        offDown = offUp = offRight = offLeft = false;

        if (CompareTag("Enemy") || CompareTag("PlayerProjectile") || CompareTag("EnemyProjectile"))
            keepOnScreen = false;

        if (position.x > CamWidth - radius) 
        {
            position.x = CamWidth - radius;
            offRight = true;
        }

        if (position.x < radius - CamWidth)
        {
            position.x = radius - CamWidth;
            offLeft = true;
        }

        if (position.y > CamHeight - radius)
        {
            position.y = CamHeight - radius;
            offUp = true;
        }

        if (position.y < radius - CamHeight)
        {
            position.y = radius - CamHeight;
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

        Vector3 borders = new Vector3(CamWidth * 2, CamHeight * 2, 0.1f);

        Gizmos.DrawWireCube(Vector3.zero, borders);
    }
}
