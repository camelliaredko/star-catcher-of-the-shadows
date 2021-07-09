using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeX;
	public float margin;
	public float followSpeed = 0.5f;
	public GameObject player;
	public Transform sceneLeft;
	public Transform sceneRight;
	private bool enableFollow = false;
	private float sideOffset;

	void Start() {
		Camera theCamera = GetComponent<Camera>();
		sideOffset = theCamera.orthographicSize * theCamera.aspect;
	}
	
	void FixedUpdate() {
		CheckPlayerPosition();
		if (enableFollow) {
			ExecuteFollow();
		}
	}

	void CheckPlayerPosition() {
		float cameraRight = transform.position.x + sideOffset;
		float cameraLeft = transform.position.x - sideOffset;
		if (cameraRight - player.transform.position.x < margin 
		    && cameraRight < sceneRight.position.x) {
			enableFollow = true;
		} else if (cameraLeft - player.transform.position.x > -margin
		           && cameraLeft > sceneLeft.position.x) {
			enableFollow = true;
		} else {
			enableFollow = false;
		}
	}

	void ExecuteFollow() {
		Vector3 targetPosition = new Vector3(player.transform.position.x,
		                                     transform.position.y,
		                                     transform.position.z);

		transform.position = Vector3.Lerp (transform.position,
		                                   targetPosition,
		                                   followSpeed);
	}

}
