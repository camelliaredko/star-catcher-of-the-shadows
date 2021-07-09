using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public float playerSpeed = 2.0f;
	public float playerJumpSpeed = 3.0f;
	private bool grounded = true;
	private bool oldGrounded = true;
	public Transform groundCheckLD;
	public Transform groundCheckLU;
	public Transform groundCheckRD;
	public Transform groundCheckRU;
	private Rigidbody2D rigidBody2D;
	private Animator animator;

	public GameObject blindingCover;
	[SerializeField] private Image customImage;

	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		blindingCover.SetActive(false);
	}

	void Update () {
		CheckGround();
		if (grounded) {
			SetHorizontalSpeed();
			if (Input.GetButton("Jump")) {
				StartPlayerJump();
				grounded = false;
			}
		}
		if (oldGrounded^grounded) {
 			animator.SetTrigger("changeState");
		}
	}

	void CheckGround() {
		oldGrounded = grounded;
		bool grounded1 = Physics2D.Linecast(groundCheckLU.position, 
		                                    groundCheckLD.position, 
		                                    1 << LayerMask.NameToLayer("Ground"));
		bool grounded2 = Physics2D.Linecast(groundCheckRU.position, 
		                                    groundCheckRD.position, 
		                                    1 << LayerMask.NameToLayer("Ground"));
		grounded = grounded1 || grounded2;
	}

	void SetHorizontalSpeed() {
		float speed = Input.GetAxis ("Horizontal") * playerSpeed;
		rigidBody2D.velocity = new Vector3(speed,0f,0f);
		Vector3 scale = transform.localScale;
		if ( (speed>0f && scale.x<0f) || (speed<0f && scale.x>0f) ) {
			scale.x = -scale.x;
		}
		transform.localScale = scale;
	}

	void StartPlayerJump() {
		Vector3 playerVelocity = rigidBody2D.velocity;
		playerVelocity.y = playerJumpSpeed;
		rigidBody2D.velocity = playerVelocity;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Curtain")
            {
            	blindingCover.SetActive(false);
				blindingCover.SetActive(true);
				blindingCover.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, -10));
				customImage.enabled = true;
            }
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Curtain")
            {
				blindingCover.SetActive(false);
				customImage.enabled = false;
            }
	}
}

