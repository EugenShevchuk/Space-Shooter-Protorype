using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] private float scrollSpeed;
	[SerializeField] private float tileWidth;
  
	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;	
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileWidth);
		transform.position = startPosition + Vector3.down * newPosition;
	}
}