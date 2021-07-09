using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		audioSource.Play();
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		Invoke("DestroySelf",audioSource.clip.length);
	}

	void DestroySelf() {
		Destroy(this.gameObject);
	}
}
