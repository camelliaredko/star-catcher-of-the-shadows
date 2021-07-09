using UnityEngine;
using System.Collections;

// a. Put the script below on any visible game object that has a collider.
// b. Click on the game object during game play. 
// c. Look for the image file just inside your project folder. 
	
public class ScreenShot : MonoBehaviour {
	void OnMouseDown() {
		ScreenCapture.CaptureScreenshot("Screenshot.png");
	}
}