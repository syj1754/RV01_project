using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CameraControl : MonoBehaviour
{

	public Camera MainCamera;
	public Camera OverlookCamera;
  public Camera CameraVR;
	public GameObject CameraObject;
	public GameObject head;
  public GameObject RightHand;
  public GameObject LeftHand;
  public GameObject BodyRightHand;
  public GameObject BodyLeftHand;
	public SteamVR_Action_Boolean triggerClick;
    public SteamVR_Action_Boolean interfaceClick;
    private Button[] box=new Button[10];
    private bool isInterface=false;
    private int index=0;
    // Start is called before the first frame update
    void Awake()
    {
		OverlookCamera.enabled = false;
        //UnityEngine.XR.InputTracking.disablePositionalTracking = true;
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
        transform.localRotation=Quaternion.LookRotation(new Vector3(Player.instance.hmdTransform.forward.x,0,Player.instance.hmdTransform.forward.z));
        CameraObject.transform.position = head.transform.position + CameraObject.transform.forward*0.08f - CameraObject.transform.right*0f + CameraObject.transform.up*0.05f;
        LeftHand.transform.position = BodyLeftHand.transform.position;
        RightHand.transform.position = BodyRightHand.transform.position;
    }
    private void CameraOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(!isInterface){
        	//MainCamera.enabled=!MainCamera.enabled;
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
