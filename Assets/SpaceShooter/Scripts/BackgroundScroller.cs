using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] private float scrollSpeed;
	[SerializeField] private float tileWidth;
  
	private Vector3 startPosition;

	void Start ()
	{
		this.startPosition = this.transform.position;	
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * this.scrollSpeed, this.tileWidth);
		this.transform.position = this.startPosition + Vector3.down * newPosition;
	}
}