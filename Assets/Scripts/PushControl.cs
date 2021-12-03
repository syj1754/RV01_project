using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PushControl : MonoBehaviour
{
	public GameObject rightArm;
	public GameObject leftArm;
	private Rigidbody rbLeft;
	private Rigidbody rbRight;
	private Vector3 pointLeft;
	private Vector3 pointRight;
	private bool isRightForce = false;
	private bool isLeftForce = false;
	public GameObject canvas;
	public GameObject handPrefab;
	private GameObject handLeft;
	private GameObject handRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
    	
    	Ray rayLeft =new Ray(leftArm.transform.position, transform.forward);
    	Ray rayRight =new Ray(rightArm.transform.position, transform.forward);
    	Debug.DrawRay(rayLeft.origin, rayLeft.direction, Color.blue);
    	Debug.DrawRay(rayRight.origin, rayRight.direction, Color.blue);
    	RaycastHit hitLeft;
    	RaycastHit hitRight;
    	if(isLeftForce){
			rbLeft.AddForceAtPosition(rayLeft.direction*8f,pointLeft);
		}else if(!handLeft && Physics.Raycast(rayLeft.origin, rayLeft.direction, out hitLeft, 1f, 1)){
        	handLeft=Instantiate(handPrefab, new Vector3(-10,-10,0), Quaternion.identity) as GameObject;
        	handLeft.transform.SetParent(canvas.transform, false);
   		}else if(handLeft && !Physics.Raycast(rayLeft.origin, rayLeft.direction, out hitLeft, 1f, 1)){
        	Destroy(handLeft);
   		}
		if(isRightForce){
			rbRight.AddForceAtPosition(rayRight.direction*8f,pointRight);
		}else if(!handRight && Physics.Raycast(rayRight.origin, rayRight.direction, out hitRight, 1f, 1)){
        	handRight=Instantiate(handPrefab, new Vector3(10,-10,0), Quaternion.identity) as GameObject;
        	handRight.transform.SetParent(canvas.transform, false);
    	}else if(handRight && !Physics.Raycast(rayRight.origin, rayRight.direction, out hitRight, 1f, 1)){
        	Destroy(handRight);
    	}
    }
    void OnPushLeft(InputValue value){
    	if(value.isPressed){
    		Ray rayLeft =new Ray(leftArm.transform.position, transform.forward);
    		//Ray rayRight =new Ray(rightArm.transform.position, transform.forward);
    		RaycastHit hitLeft;
    		//RaycastHit hitRight;
    		if(Physics.Raycast(rayLeft.origin, rayLeft.direction, out hitLeft, 1f, 1)){
    			rbLeft=hitLeft.rigidbody;
    			pointLeft=hitLeft.point;
    			isLeftForce = true;
    		}
    		/*if(Physics.Raycast(rayRight.origin, rayRight.direction, out hitRight, 1f, 1)){
    			Debug.Log("PushRight");
    			rbRight=hitRight.rigidbody;
    			pointRight=hitRight.point;
    			isRightForce = true;
    		}*/
    		StartCoroutine(DelayAction(0.5f,true));
    	}
    }
    void OnPushRight(InputValue value){
    	if(value.isPressed){
    		//Ray rayLeft =new Ray(leftArm.transform.position, transform.forward);
    		Ray rayRight =new Ray(rightArm.transform.position, transform.forward);
    		//RaycastHit hitLeft;
    		RaycastHit hitRight;
    		/*if(Physics.Raycast(rayLeft.origin, rayLeft.direction, out hitLeft, 1f, 1)){
    			Debug.Log("PushLeft");
    			rbLeft=hitLeft.rigidbody;
    			pointLeft=hitLeft.point;
    			isLeftForce = true;
    		}*/
    		if(Physics.Raycast(rayRight.origin, rayRight.direction, out hitRight, 1f, 1)){
    			rbRight=hitRight.rigidbody;
    			pointRight=hitRight.point;
    			isRightForce = true;
    		}
    		StartCoroutine(DelayAction(0.5f,false));
    	}
    }
    IEnumerator DelayAction(float delayTime, bool isLeft)
	{
   		//Wait for the specified delay time before continuing.
   		yield return new WaitForSeconds(delayTime);
   		if(isLeft){
   			isLeftForce = false;
   		}else{
 			isRightForce = false;
 		}
	}
}
