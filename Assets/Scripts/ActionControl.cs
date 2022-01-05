using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEditor;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ActionControl : MonoBehaviour
{
	public SteamVR_Action_Vector2 move;
	//public SteamVR_Action_Vector2 camera;
	private StarterAssetsInputs _input;
    private float x = 0;
    private float z = 0;
	public SteamVR_Action_Boolean jump;
    // Start is called before the first frame update
    void Start()
    {
        move.AddOnUpdateListener(VectorOption,SteamVR_Input_Sources.Any);
        //camera.AddOnUpdateListener(PoseOption,SteamVR_Input_Sources.Camera);
        jump.AddOnStateUpListener(JumpOption, SteamVR_Input_Sources.Any);
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation=Player.instance.hmdTransform.localRotation;
    }
    private void VectorOption(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource,Vector2 axis, Vector2 delta)
    {
        //put your stuff here
        Debug.Log("Success!!" + axis);
        _input.move=new Vector2(Player.instance.hmdTransform.position.x-x+axis.x,Player.instance.hmdTransform.position.z-z+axis.y);
        x=Player.instance.hmdTransform.position.x;
        z=Player.instance.hmdTransform.position.z;

    }
    private void JumpOption(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success jump!!");
        _input.jump=true;

    }
}
