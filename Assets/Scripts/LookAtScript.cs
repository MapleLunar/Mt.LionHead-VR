using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {
    public Transform target;

	public GameObject ControllerRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<MeshRenderer>().enabled = !ControllerRight.gameObject.GetComponent<ControllerRightScript>().GetPhoto;
		//this.gameObject.SetActive(!ControllerRight.gameObject.GetComponent<ControllerRightScript>().GetTouchVal);
        transform.LookAt(target);
        this.transform.Rotate(0, 180, 0);
    }
}
