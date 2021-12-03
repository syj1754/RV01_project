using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteControl : MonoBehaviour
{
	private Rigidbody rb;
	private Mesh mesh;
	private bool isForce = false;
	public bool isRight;
	private Vector3 pointForce;
    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
    	mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
    	if(isForce){
    		float force=5;
    		if(isRight){
    			force*=-1;
    		}
    		rb.AddForceAtPosition(new Vector3(0,0,force),new Vector3(transform.position.x+1,transform.position.y,transform.position.z));
		}

    }
    private void OnCollisionEnter(Collision other)
    {
    	Debug.Log("test false");
        if(other.gameObject.tag=="Player"){
        	Debug.Log("test");
        	isForce = true;
        	StartCoroutine(DelayAction(0.1f));
    	}
    }
    IEnumerator DelayAction(float delayTime)
	{
   		//Wait for the specified delay time before continuing.
   		yield return new WaitForSeconds(delayTime);
 
   		isForce = false;
	}
}
