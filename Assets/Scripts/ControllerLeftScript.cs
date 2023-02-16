using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerLeftScript : MonoBehaviour {
	public SteamVR_TrackedObject mTrackeObject = null;
	public GameObject Camera;
	public GameObject CameraRig;
	public GameObject ControllerRight;
	public SteamVR_Controller.Device mDevice;
	// Use this for initialization
	void Start () {
		mTrackeObject = GetComponent<SteamVR_TrackedObject> ();
		mDevice = SteamVR_Controller.Input ((int)mTrackeObject.index);
	}
	
	// Update is called once per frame
	void Update () {
		if(mDevice!=null){
			if (mDevice.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
				
			}

			if (mDevice.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
				
			}

			
			if (mDevice.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
				ControllerRight.gameObject.GetComponent<ControllerRightScript>().GetPhotoOn();
			}


			if (mDevice.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
				
			}
			

			//Vector2 triggerValue = mDevice.GetAxis (EVRButtonId.k_EButton_SteamVR_Trigger);

			if (mDevice.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
				Vector2 touchValue = mDevice.GetAxis (EVRButtonId.k_EButton_SteamVR_Touchpad);
				if(!ControllerRight.gameObject.GetComponent<ControllerRightScript>().GetPhoto){
					//限制移動區域
					if(CameraRig.transform.position.x<12){
						CameraRig.transform.position = new Vector3(12f,CameraRig.transform.position.y,CameraRig.transform.position.z);
					}
					
					if(CameraRig.transform.position.z<11.2){
						CameraRig.transform.position = new Vector3(CameraRig.transform.position.x,CameraRig.transform.position.y,11.2f);
					}

					if(CameraRig.transform.position.x>379.9){
						CameraRig.transform.position = new Vector3(379.9f,CameraRig.transform.position.y,CameraRig.transform.position.z);
					}

					if(CameraRig.transform.position.z>380){
						CameraRig.transform.position = new Vector3(CameraRig.transform.position.x,CameraRig.transform.position.y,380f);
					}
					CameraRig.transform.position+=Camera.transform.forward*touchValue.y+Camera.transform.right*touchValue.x;
				}
			}

			if (mDevice.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
				
			}
		}else{	
			mDevice = SteamVR_Controller.Input ((int)mTrackeObject.index);
		}

		
	}


	
}

