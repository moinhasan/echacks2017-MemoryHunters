using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour {

  //Gyro
	private Gyroscope gyro;
	private GameObject cameraContainer;
	private Quaternion rotation;

	//Cam
	private WebCamTexture cam;
	public RawImage background;
	public AspectRatioFitter fit;

	private bool arReady = false;

	private void Start(){
		// check if support both services
		//Gyroscope
		if (!SystemInfo.supportsGyroscope) {
			Debug.Log ("This device does not have Gyroscope");
			return;
		}
		//Back Camera
		for (int i = 0; i < WebCamTexture.devices.Length; i++) {
			if (!WebCamTexture.devices [i].isFrontFacing) {
				cam = new WebCamTexture (WebCamTexture.devices [i].name, Screen.width, Screen.height);
				break;
			}
		}

		//if we did not find a back camera, exit
		//This code doesn't do anything, only check if service is avaliable or not
		if (cam == null) {

			Debug.Log ("This device does not have back camera");
			return;
		}
		//Both services are supported, let's enable them!
		cameraContainer = new GameObject("Camera Container");
		cameraContainer.transform.position = transform.position;
		//transform is the children of the camera container
		transform.SetParent(cameraContainer.transform);

		gyro = Input.gyro;
		gyro.enabled = true;

		cam.Play ();
		background.texture = cam;

		arReady = true;
	}

	private void Update()
	{
		if (arReady) {

			//Update Camera, because camera always delay while running
			float ratio = (float)cam.width / (float)cam.height;
			//this will make it fit to the screen
			fit.aspectRatio = ratio;

			//check if the video vertically mirrored, if it's do -1.0f, if not do 1.0f
			float scaleY = cam.videoVerticallyMirrored ? -1.0f: 1.0f;
			background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

			int orient = -cam.videoRotationAngle;
			background.rectTransform.localEulerAngles = new Vector3(0, 0,orient);
		
			//Update Gyro
			transform.localRotation = gyro.attitude *rotation;


		}
	}
}
