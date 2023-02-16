using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using System.Text;

public class ControllerRightScript : MonoBehaviour {
    public SteamVR_TrackedObject mTrackeObject = null;
    public GameObject BuildingPhotoBall; //建築物圖片球
    public GameObject Camera;
    public GameObject CameraRig;
    public Text UIText;  //資訊文字UI
    public Image UIImage; //資訊背景UI
    public GameObject Sign; //紅點
    public GameObject Terrain;       //地形
    public GameObject[] Building;   //建築物
    public Material[] BuildingPhoto ;//建築物圖片
    public GameObject[,] TestArr2;
	public TextAsset[] TxtFile; //資訊文字檔
    string[] BuildingInformationText= new string[1000]; //資訊文字
    RaycastHit hit;
	public bool GetPhoto=false; 
	public SteamVR_Controller.Device mDevice;
	int currentI;
	void Start () {
        TestArr2 = new GameObject[36,5];
		mTrackeObject = GetComponent<SteamVR_TrackedObject> ();
		mDevice = SteamVR_Controller.Input ((int)mTrackeObject.index);

		for(int i=0;i<TxtFile.Length;i++){
			//讀取所有text檔
			BuildingInformationText[i]=TxtFile[i].text; 
		}

		Terrain.gameObject.SetActive(true); //顯示地形
		for(int i=0;i<Building.Length;i++){
			Building[i].gameObject.SetActive(true); //顯示建築物
		}
		BuildingPhotoBall.gameObject.SetActive(false);//隱藏建築物圖片球
		UIText.gameObject.SetActive(false);//隱藏資訊文字UI
		UIImage.gameObject.SetActive(false);//資訊背景UI
	}

	// Update is called once per frame
	void Update () {
		//Trigger.transform.position=new Vector3(this.transform.position.x+2,this.transform.position.y,this.transform.position.z);
		if(hit.collider!=null){
			//當hit到gameObject的tag為building_tag時，顯示UI
            UIText.gameObject.SetActive(hit.collider.tag=="building_tag");
			UIImage.gameObject.SetActive(hit.collider.tag=="building_tag");
        }else{
			UIText.gameObject.SetActive(false);
			UIImage.gameObject.SetActive(false);
		}
		BuildingPhotoBall.gameObject.SetActive (GetPhoto); //設定球
		Terrain.gameObject.SetActive(!GetPhoto); //顯示地形
		for(int i=0;i<Building.Length;i++){
			Building[i].gameObject.SetActive(!GetPhoto); //顯示建築物
		}


		if(mDevice!=null){
			if (mDevice.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu)) {

			}

			if (mDevice.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {

			}


			if (mDevice.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
				GetPhoto = false;
			}


			if (mDevice.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {

			}


			//Vector2 triggerValue = mDevice.GetAxis (EVRButtonId.k_EButton_SteamVR_Trigger);
			for (int i = 0; i < Building.Length; i++) {
				if (mDevice.GetPress(SteamVR_Controller.ButtonMask.Grip)) {
					//當Get Grip時，顯示紅點
					Sign.gameObject.SetActive(true);
					if (Physics.Raycast(transform.position, this.transform.forward, out hit, 200)){
						//print(hit.collider.transform.name);
						if (hit.collider.transform.name == Building [i].name) {
							Building [i].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
							//設定UIText為目前hit到的資訊
							UIText.text=BuildingInformationText[i];
							//設定球為目前hit到的照片
							BuildingPhotoBall.GetComponent<MeshRenderer>().material = BuildingPhoto[i];
							
						}else{//hit
                    		Building[i].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    		//UIText.gameObject.SetActive(false);
                		}
					}else{//Raycast
                		Building[i].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            		}
        		Debug.DrawRay(transform.position, this.transform.forward * 200, Color.red);
				}else{//Grip
                	Building[i].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
					Sign.gameObject.SetActive(false);
                	UIText.gameObject.SetActive(false);
					UIImage.gameObject.SetActive(false);
            	}	
			}
				

			if (mDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) {
				GetPhotoOn();
			}


			if (mDevice.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
				Vector2 touchValue = mDevice.GetAxis (EVRButtonId.k_EButton_SteamVR_Touchpad);
				if(!GetPhoto){
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
    public void GetPhotoOn(){
        if(hit.collider!=null){
            if(hit.collider.tag=="building_tag"){
                GetPhoto = true;
            }
        }
    }


}

