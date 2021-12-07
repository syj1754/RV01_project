using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Valve.VR;

public class CameraControl : MonoBehaviour
{

	public Camera MainCamera;
	public Camera OverlookCamera;
	public GameObject CameraObject;
	public GameObject head;
	public SteamVR_Action_Boolean triggerClick;
    // Start is called before the first frame update
    void Awake()
    {
		OverlookCamera.enabled = false;
    }
    void Start()
    {
    	triggerClick.AddOnStateUpListener(CameraOption, SteamVR_Input_Sources.Any);
    	//OverlookCamera.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        CameraObject.transform.position = head.transform.position + CameraObject.transform.forward*0.05f - CameraObject.transform.right*0.15f + CameraObject.transform.up*0.05f;
    }
    private void CameraOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        MainCamera.enabled=!MainCamera.enabled;
		OverlookCamera.enabled=!OverlookCamera.enabled;
    }
    void OnCameraOption(InputValue value){
    	if(value.isPressed){
    		MainCamera.enabled=!MainCamera.enabled;
			OverlookCamera.enabled=!OverlookCamera.enabled;
		}
    }
}
