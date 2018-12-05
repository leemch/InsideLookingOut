using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject target;
    public float followAhead;
    private Vector3 targetPosition;

    public float smoothing;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if(target.transform.localScale.x > 0f)
        {
           targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
            //targetPosition = new Vector3(targetPosition.x + followAhead, transform.position.y, targetPosition.z);
        }
        else
        {
            targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            //targetPosition = new Vector3(targetPosition.x - followAhead, transform.position.y, targetPosition.z);

        }


        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing*Time.deltaTime);

        //Vector3 newPosition = targetPosition;
        //newPosition.x = Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * smoothing);

 
        //transform.position = newPosition;
    }
}
