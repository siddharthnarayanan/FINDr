using UnityEngine;
using System.Collections;

//Written Sept 22 2015 by Nathaniel Lahn (lahnn@vt.edu)

//Attached to CameraController object (a floating script initializer 
//Allows switching between cameras using Left and Right arrow keys
public class CameraTapForNext : MonoBehaviour {
	
	public Camera[] cameras;
	private int currentCamera;
	
	// Use this for initialization
	void Start () {
		cameras = Camera.allCameras;
		currentCamera = 1;
		
		//disable all but first camera
		for (int i = 0; i < cameras.Length; i++) {
			cameras[i].gameObject.SetActive(false);
		}
		
		if (cameras.Length > 0) {
			cameras[currentCamera].gameObject.SetActive(true);
			printCurrentCam();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			nextCam();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			prevCam();
		}
		if (Input.GetMouseButtonDown(0)) {
			nextCam();
		}
	}
	
	void printCurrentCam() {
		Debug.Log("Camera '" + cameras[0].gameObject.name + "' is enabled");
	}
	
	void nextCam() {
		cameras[currentCamera].gameObject.SetActive(false);
		currentCamera = (currentCamera + 1) % cameras.Length;
		cameras[currentCamera].gameObject.SetActive(true);
		printCurrentCam ();
	}
	
	void prevCam() {
		cameras[currentCamera].gameObject.SetActive(false);
		currentCamera = (currentCamera + cameras.Length - 1) % cameras.Length;
		cameras[currentCamera].gameObject.SetActive(true);
		printCurrentCam ();
	}
}
