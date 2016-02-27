using UnityEngine;
using System.Collections;
using System.IO;

public class camer : MonoBehaviour {

	WebCamTexture front;
	WebCamTexture saveImg;

	float timeGap;
	float timeLimit;
	int photoNum;

	void Start () {

		front = new WebCamTexture ();

		GetComponent<Renderer> ().material.mainTexture = front;
		front.Play ();

		if (front.isPlaying){
			GetComponent<Renderer> ().material.mainTexture = front;
			}

		timeGap = 3f;
		timeLimit = timeGap;

		photoNum = 0;
	
		//print(Application.persistentDataPath);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > timeLimit) {
			
			saveImg = front;

			TakePhoto ();
			photoNum += 1;

			timeLimit = Time.time + timeGap;

		}
	
	}

	void TakePhoto()
	{

		Texture2D photo = new Texture2D(saveImg.width, saveImg.height);
		photo.SetPixels(saveImg.GetPixels());
		photo.Apply();

		//Encode to a PNG
		byte[] bytes = photo.EncodeToPNG();
		string path = "/Users/Nighttac";
		string photoName = "photo " + photoNum + ".png";

		//Write out the PNG
		System.IO.File.WriteAllBytes (Application.persistentDataPath + photoName, bytes);
		//File.Move (file, macPath);

		Debug.Log ("photo" + photoNum + "is taken");


	}

}
