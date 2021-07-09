using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	private AudioSource audioSource;
	private Rigidbody2D rigidBody;
	public float enemyImpulse;
	private bool touchingCurtain = false;
	private Renderer rend;

	[SerializeField]
	private Color colorToTurnTo = Color.white;
	
	void Start() {
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(2f,0f);
		Physics2D.IgnoreLayerCollision(12, 6, false);
	}


    void Update()
    {
		if(!touchingCurtain && -2 < rigidBody.velocity.x && rigidBody.velocity.x < 2 || rigidBody.velocity.x > 2 || rigidBody.velocity.x < -2) {
			if(Random.Range(0f, 1f) < 0.5f) {
		rigidBody.velocity = new Vector2(2f,0f);
			} else {
				rigidBody.velocity = new Vector2(-2f,0f);
			}
		}
    }

	void OnCollisionEnter2D(Collision2D collision) {
		GameObject other = collision.gameObject;
		if (other.tag=="Player") {
		audioSource.Play();
		Health hearts = other.GetComponent<Health>();
		hearts.health -= 1;
        if (hearts.health < 1){
			CollectStar.starsCollected = 0;
            Application.LoadLevel(Application.loadedLevel);
        }		
		rigidBody.velocity = Vector3.zero;
		rigidBody.velocity = new Vector2(2f,0f);
		}
	} 

	void FixedUpdate() {
		Vector3 scale = transform.localScale;
		if (rigidBody.velocity.x > 0f) {
			transform.localScale = new Vector3 (Mathf.Abs(scale.x), scale.y, scale.z);
		} else {
			transform.localScale = new Vector3 (-Mathf.Abs(scale.x), scale.y,  scale.z);			
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{		
        if (collision.gameObject.tag == "Curtain")
            {
				touchingCurtain = true;
				rigidBody.velocity = Vector3.zero;
				rend = GetComponent<Renderer>();
				rend.material.color = colorToTurnTo;
            }
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Curtain")
            {
                rigidBody.velocity = Vector3.zero;
				rend = GetComponent<Renderer>();
				rend.material.color = colorToTurnTo;
            }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Curtain")
            {
				touchingCurtain = false;
				rigidBody.AddForce(new Vector2(enemyImpulse*rigidBody.mass,0f));  
				rend = GetComponent<Renderer>();
				rend.material.color = Color.white;
			}
	}
}

