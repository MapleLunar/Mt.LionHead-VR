using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightScript : MonoBehaviour {
	RaycastHit hit;
	float distance;//距離差
	int high=10;//最高距離
	int low=5;//最低距離
	void Start () {
		
	}
	void Update () {
		//偵測相機距離
		if(Physics.Raycast (transform.position, -this.transform.up, out hit, 200)){ 
			if (hit.distance < low) { 
				distance = low - hit.distance; 
			} else if (hit.distance > high) {
				distance = -(hit.distance - high);
			} else {
				distance = 0;			
			}
		}
		//調整距離
		this.transform.position += new Vector3(0,distance,0);
	}
}
