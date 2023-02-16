using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoPlaybackScript : MonoBehaviour {
    public GameObject sphere;
	public GameObject ControllerRight;
    //public VideoClip video360;

    private VideoPlayer videoPlayer;
    // Use this for initialization
    void Start () {
        //videoPlayer = gameObject.AddComponent<VideoPlayer>();
        // MovieTexture video360 = (MovieTexture)Sphere.GetComponent<Renderer>().material.mainTexture;
        videoPlayer = sphere.GetComponent<VideoPlayer>();

                
    }
    void Update()
    {
		if (ControllerRight.gameObject.GetComponent<ControllerRightScript>().GetPhoto) {
			videoPlayer.Play ();
		}else {
			videoPlayer.Pause ();
		}
    }
		

}