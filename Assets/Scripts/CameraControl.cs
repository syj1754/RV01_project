using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CameraControl : MonoBehaviour
{

	public Camera MainCamera;
	public Camera OverlookCamera;
    public Camera CameraVR;
	public GameObject CameraObject;
	public GameObject head;
	public SteamVR_Action_Boolean triggerClick;
    public SteamVR_Action_Boolean interfaceClick;
    public SteamVR_Action_Boolean menu;
    public Button[] box;
    private bool isStopped=false;
    private bool isInterface=false;
    private int index=0;
    // Start is called before the first frame update
    void Awake()
    {
        if(OverlookCamera!=null){
            OverlookCamera.enabled = false;
            if(Player.instance.hmdTransform==null){
                CameraVR.enabled = false;
            }
        }
        //UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    }
    void Start()
    {

        menu.AddOnStateUpListener(MenuOption, SteamVR_Input_Sources.Any);
    	triggerClick.AddOnStateUpListener(CameraOption, SteamVR_Input_Sources.Any);
    	interfaceClick.AddOnStateUpListener(InterfaceOption, SteamVR_Input_Sources.Any);
        //OverlookCamera.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Player.instance.hmdTransform.rotation=Quaternion.Euler(20.0f, 50.0f, 0.0f);
        //Player.instance.hmdTransform.rotation=Quaternion.LookRotation(new Vector3(0,Player.instance.hmdTransform.forward.y,0));
        if (CameraObject!=null){
            CameraObject.transform.position = head.transform.position + head.transform.forward*0.1f + head.transform.up*0.05f;
        }
        if (OverlookCamera!=null){
            if (OverlookCamera.enabled==true){
                if(isStopped){
                    OverlookCamera.transform.rotation=MainCamera.transform.rotation;
                    //OverlookCamera.transform.rotation=Quaternion.LookRotation(new Vector3(Player.instance.hmdTransform.forward.x,Player.instance.hmdTransform.forward.y,Player.instance.hmdTransform.forward.z));
                }else{
                    OverlookCamera.transform.position=new Vector3(transform.position.x,15,transform.position.z);
                    OverlookCamera.transform.rotation=Quaternion.LookRotation(new Vector3(Player.instance.hmdTransform.forward.x+90,Player.instance.hmdTransform.forward.y,Player.instance.hmdTransform.forward.z));
                }
            }else{
                transform.rotation=Quaternion.LookRotation(new Vector3(Player.instance.hmdTransform.forward.x,0,Player.instance.hmdTransform.forward.z));
            }
        }
    }
    private void CameraOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(!isInterface){
        	//MainCamera.enabled=!MainCamera.enabled;
            if (OverlookCamera!=null){
                OverlookCamera.enabled=!OverlookCamera.enabled;
            }
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
    private void MenuOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success jump!!");
        isStopped=!isStopped;
            if(isStopped){
                OverlookCamera.enabled=true;
                SceneManager.LoadScene("StartingScene", LoadSceneMode.Additive);
            }else{
                SceneManager.UnloadSceneAsync("StartingScene");
                OverlookCamera.enabled=false;
            }

    }
    void OnCameraOption(InputValue value){
    	if(value.isPressed){
    		MainCamera.enabled=!MainCamera.enabled;
			OverlookCamera.enabled=!OverlookCamera.enabled;
		}
    }
    void OnStop(InputValue value){
        if(value.isPressed){
            isStopped=!isStopped;
            if(isStopped){
                OverlookCamera.enabled=true;
                SceneManager.LoadScene("StartingScene", LoadSceneMode.Additive);
            }else{
                SceneManager.UnloadSceneAsync("StartingScene");
                OverlookCamera.enabled=false;
            }
        }
    }
}
