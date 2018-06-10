using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamingVideo : MonoBehaviour {

	private string url="";
	//public VideoClip videoToPlay;
	public VideoPlayer videoPlayer;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		Application.runInBackground = false;
	}

	public void playVideoLoad(string url){
        this.url = url;
		StartCoroutine(playVideo ());
	}

	IEnumerator playVideo()
	{

		Debug.Log ("play video");

		//Add VideoPlayer to the GameObject
		videoPlayer = gameObject.AddComponent<VideoPlayer>();

		//Add AudioSource
		//audioSource = gameObject.AddComponent<AudioSource>();

		//Set Audio Output to AudioSource
		//videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;


		//Assign the Audio from Video to AudioSource to be played
		//videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = true;
		//audioSource.playOnAwake = true;
		//audioSource.Pause();

		// Vide clip from Url
		videoPlayer.source = VideoSource.Url;

		videoPlayer.url =this.url;


		//Set video To Play then prepare Audio to prevent Buffering
		//videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();

		//Wait until video is prepared
		WaitForSeconds waitTime = new WaitForSeconds(0);
		while (!videoPlayer.isPrepared)
		{
			//Debug.Log("Preparing Video");
			//Prepare/Wait for 5 sceonds only
			yield return waitTime;
			//Break out of the while loop after 5 seconds wait
			break;
		}

		Debug.Log("Done Preparing Video");

		//Assign the Texture from Video to RawImage to be displayed
		//image.texture = videoPlayer.texture;

		//Play Video
		videoPlayer.Play();

		//Play Sound
		//audioSource.Play();

		Debug.Log("Playing Video");
		while (videoPlayer.isPlaying)
		{
			//Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
			yield return null;
		}

		Debug.Log("Done Playing Video");
	}

}