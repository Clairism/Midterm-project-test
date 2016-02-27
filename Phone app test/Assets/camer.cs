using UnityEngine;
using System.Collections;
using System.IO;

public class camer : MonoBehaviour {

	WebCamTexture front;
	WebCamTexture saveImg;

	//float time;
	float timeLimit;
	int photoNum;

	void Start () {

		front = new WebCamTexture ();

		GetComponent<Renderer> ().material.mainTexture = front;
		front.Play ();

		if (front.isPlaying){
			GetComponent<Renderer> ().material.mainTexture = front;
			}

		//time = 0.0f;
		timeLimit = 0.02f;
	
		photoNum = 0;
	
		print(Application.persistentDataPath);

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.deltaTime > timeLimit) {
			//Debug.Log (Time.deltaTime);
			
			saveImg = front;

			TakePhoto ();
			photoNum += 1;

			//time = 0.0f;
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
