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
    public Button button1;
    public Button button2;
    public Button button3;
	public GameObject CameraObject;
	public GameObject head;
	public SteamVR_Action_Boolean triggerClick;
    public SteamVR_Action_Boolean interfaceClick;
    private Button[] box=new Button[10];
    private bool isInterface=false;
    private int index=-1;
    // Start is called before the first frame update
    void Awake()
    {
		OverlookCamera.enabled = false;
        if(Player.instance.hmdTransform==null){
            CameraVR.enabled = false;
        }
        //UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    }
    void Start()
    {
    	triggerClick.AddOnStateUpListener(CameraOption, SteamVR_Input_Sources.Any);
    	interfaceClick.AddOnStateUpListener(InterfaceOption, SteamVR_Input_Sources.Any);
    	box[0]=button1;
    	box[1]=button2;
        box[2]=button3;
    	//OverlookCamera.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Player.instance.hmdTransform.rotation=Quaternion.Euler(20.0f, 50.0f, 0.0f);
        //Player.instance.hmdTransform.rotation=Quaternion.LookRotation(new Vector3(0,Player.instance.hmdTransform.forward.y,0));
        CameraObject.transform.position = head.transform.position + head.transform.forward*0.1f + head.transform.up*0.05f;
        if(OverlookCamera.enabled==true){
            OverlookCamera.transform.position=new Vector3(transform.position.x,15,transform.position.z);
            OverlookCamera.transform.rotation=Quaternion.LookRotation(new Vector3(Player.instance.hmdTransform.forward.x+90,Player.instance.hmdTransform.forward.y,Player.instance.hmdTransform.forward.z));
        }else{
            transform.rotation=Quaternion.LookRotation(new Vector3(Player.instance.hmdTransform.forward.x,0,Player.instance.hmdTransform.forward.z));
        }
    }
    private void CameraOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(!isInterface){
        	//MainCamera.enabled=!MainCamera.enabled;
			OverlookCamera.enabled=!OverlookCamera.enabled;
		}else{
            isInterface=!isInterface;
            box[index].onClick.Invoke();;
            index=0;
        }
    }
    private void InterfaceOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(!isInterface){
        	isInterface=!isInterface;
        	box[index].Select();
            index++;

        }else{
        	box[index].Select();
            index++;
        }
    }
    void OnCameraOption(InputValue value){
    	if(value.isPressed){
    		MainCamera.enabled=!MainCamera.enabled;
			OverlookCamera.enabled=!OverlookCamera.enabled;
		}
    }
}
