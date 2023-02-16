using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{  
	public GameObject BuildingPhotoBall ; //建築物圖片球
    void Start()
	{	
			
    }
    void Update()
    {	
        BuildingPhotoBall.transform.position = this.transform.position;//建築物圖片球與相機位置同步
    }
}