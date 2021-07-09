using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticJumpMovement : MonoBehaviour
{
	private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
		GameObject other = collision.gameObject;
		if (other.tag=="Platform") {
            rigidBody.AddForce(new Vector2(0,-1f));
            StartCoroutine("Jump");
		} 
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f); 
        rigidBody.AddForce(Vector2.up * 10);
        if(Random.Range(0f, 1f) < 0.5f) {
            rigidBody.AddForce(new Vector2(50,0f));
        } else {
            rigidBody.AddForce(new Vector2(-50,0f));
        }
    }
}




