using UnityEngine;

public class cameraFollow : MonoBehaviour {
	private Vector2 velocity;
	public Transform target;
	public float SmoothTimeX;
	public float SmoothTimeY;

	void FixedUpdate ()
	{
		if (target) {
			float PosX = Mathf.SmoothDamp(transform.position.x,target.transform.position.x, ref velocity.x,SmoothTimeX);
			float PosY = Mathf.SmoothDamp(transform.position.y,target.transform.position.y,ref velocity.y,SmoothTimeY);
			PosY	 = Mathf.Clamp(PosY,-15f,15f);
			PosX = Mathf.Clamp(PosX,-35f,35f);
			transform.position = new Vector3 (PosX,PosY,transform.position.z);
		}
	}
}
