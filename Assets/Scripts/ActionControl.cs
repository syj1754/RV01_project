using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Valve.VR;

public class ActionControl : MonoBehaviour
{
	public SteamVR_Action_Vector2 move;
	public SteamVR_Action_Pose camera;
	private StarterAssetsInputs _input;
	public SteamVR_Action_Boolean jump;
    // Start is called before the first frame update
    void Start()
    {
        move.AddOnUpdateListener(VectorOption,SteamVR_Input_Sources.Any);
        camera.AddOnUpdateListener(SteamVR_Input_Sources.Any,PoseOption);
        jump.AddOnStateUpListener(JumpOption, SteamVR_Input_Sources.Any);
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void VectorOption(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource,Vector2 axis, Vector2 delta)
    {
        //put your stuff here
        Debug.Log("Success!!" + axis);
        _input.move=axis;

    }
    private void JumpOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success jump!!");
        _input.jump=true;

    }
    private void PoseOption(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        //Debug.Log("Success!!");
        //_input.look=new Vector2(fromAction.angularVelocity.x-fromAction.lastAngularVelocity.x,fromAction.angularVelocity.y-fromAction.lastAngularVelocity.y);

    }
}
