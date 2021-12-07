using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class InterfaceControl : MonoBehaviour
{
    public SteamVR_Action_Boolean triggerClick;
    public SteamVR_Action_Boolean interfaceClick;
    private Button[] box=new Button[10];
    private bool isInterface=false;
    private int index=0;
    // Start is called before the first frame update

    void Start()
    {
    	triggerClick.AddOnStateUpListener(ButtonOption, SteamVR_Input_Sources.Any);
    	interfaceClick.AddOnStateUpListener(InterfaceOption, SteamVR_Input_Sources.Any);
    	//box[0]=;
    	//box[1]=;
    	//OverlookCamera.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void InterfaceOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(!isInterface){
        	isInterface=!isInterface;
        	//box[index]=
        	index++;
        }
    }
    private void ButtonOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success!!");
        if(isInterface){
        	isInterface=!isInterface;
        	box[index].onClick.Invoke();;
        	index=0;
        }
    }
}
