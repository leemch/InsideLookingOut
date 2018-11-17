using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformPathScript : MonoBehaviour {

    public GameObject objectToMove;
    public Transform[] points;
    public float moveSpeed;
    private Vector3 currentTarget;

    int numPoints;

    int position;

	// Use this for initialization
	void Start () {
        position = 0;
        numPoints = points.Length;
        //currentTarget = point2.position;
	}
	
	// Update is called once per frame
	void Update () {

        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);



 //       if (objectToMove.transform.position == point1.position)
 //       {
//            currentTarget = point2.position;
//        }


    }
}
