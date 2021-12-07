using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using Valve.VR;

public class CameraControl : MonoBehaviour
{

	public Camera MainCamera;
	public Camera OverlookCamera;
	public GameObject CameraObject;
	public GameObject head;
	public SteamVR_Action_Boolean triggerClick;
    public SteamVR_Action_Boolean interfaceClick;
    private Button[] box=new Button[10];
    private bool isInterface=false;
    private int index=0;
    // Start is called before the first frame update
    void Awake()
    {
		OverlookCamera.enabled = false;
    }
    void Start()
    {
    	triggerClick.AddOnStateUpListener(CameraOption, SteamVR_Input_Sources.Any);
    	interfaceClick.AddOnStateUpListener(InterfaceOption, SteamVR_Input_Sources.Any);
    	//box[0]=;
    	//box[1]=;
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
        if(!isInterface){
        	MainCamera.enabled=!MainCamera.enabled;
			OverlookCamera.enabled=!OverlookCamera.enabled;
		}
    }
    private void InterfaceOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(!isInterface){
        	isInterface=!isInterface;
        	//box[index]=
        	index++;
        }else{
        	isInterface=!isInterface;
        	box[index].onClick.Invoke();;
        	index=0;
        }
    }
    void OnCameraOption(InputValue value){
    	if(value.isPressed){
    		MainCamera.enabled=!MainCamera.enabled;
			OverlookCamera.enabled=!OverlookCamera.enabled;
		}
    }
}
