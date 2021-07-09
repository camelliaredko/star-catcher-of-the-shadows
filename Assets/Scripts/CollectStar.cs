using UnityEngine;
using System.Collections;

public class CollectStar : MonoBehaviour {
	private AudioSource audioSource;
	public GameObject myPrefab;
    public static int starsCollected = 0;

	void Start() {
		audioSource = GetComponent<AudioSource>();
		ScoringSystem.score = starsCollected;
	}

	void OnTriggerEnter2D(Collider2D collision) {
		GameObject other = collision.gameObject;
		if (other.tag=="Player") {
		audioSource.Play();
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		Invoke("DestroySelf",audioSource.clip.length);
		starsCollected++;
		ScoringSystem.score = starsCollected;
		Debug.Log(starsCollected);
        if(starsCollected % 10 == 0) {
			Debug.Log("Door open");
            Instantiate(myPrefab, new Vector3(2.7f, 20.63f, 0), Quaternion.identity);
        	}
		}
	}

	void DestroySelf() {
		Destroy(this.gameObject);
	}
}
