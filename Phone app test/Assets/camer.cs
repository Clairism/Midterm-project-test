using UnityEngine;
using System.Collections;

public class camer : MonoBehaviour {

	WebCamTexture front;

	void Start () {

		front = new WebCamTexture ();

		GetComponent<Renderer> ().material.mainTexture = front;
		front.Play ();

		if (front.isPlaying){
			GetComponent<Renderer> ().material.mainTexture = front;
			}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
