using UnityEngine;
using System.Collections;

public class KeyControl : MonoBehaviour {

	public GameObject gameManager;

	void OnTriggerEnter2D(Collider2D other) {
		gameManager.GetComponent<GameControl>().SetPlayerHasKey();
	}

}
