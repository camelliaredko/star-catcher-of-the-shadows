using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private bool playerHasKey = false;

	public void SetPlayerHasKey() {
		playerHasKey = true;
	}

	public bool GetPlayerHasKey() {
		return playerHasKey;
	}
}
