using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorControl : MonoBehaviour {

	public GameObject gameManager;
	private AudioSource audioSource;
	private int victory;
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		victory = SceneManager.GetActiveScene().buildIndex + 1;
		audioSource.Play();
	}

	void OnTriggerEnter2D(Collider2D collision) {
		GameObject other = collision.gameObject;
		if (other.tag=="Player") {
			this.GetComponent<Animator>().SetTrigger("openDoor");
			SceneManager.LoadScene(victory);
			}
		}
}
