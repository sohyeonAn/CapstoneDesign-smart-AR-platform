using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour {

	Texture2D tex;

	string url = "";

	// Use this for initialization
	void Start()
	{
		Debug.Log ("LoadImage enable");
	}

	public void getImageLoad(string url){
        this.url = url;
		StartCoroutine(getImage ());
	}

	IEnumerator getImage() {

		Debug.Log ("load Image");
		tex = new Texture2D (4, 4, TextureFormat.DXT1, false);
		WWW www = new WWW (url);
		yield return www;
		www.LoadImageIntoTexture (tex);

		GetComponent<Renderer> ().material.mainTexture = tex;

	}
		

		
}
