using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject2 : MonoBehaviour {

    public GameObject objectToMove;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;

    public float moveSpeed;

    private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
        currentTarget = point2.position;
	}
	
	// Update is called once per frame
	void Update () {

        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (objectToMove.transform.position == point1.position)
        {
            currentTarget = point2.position;
        }

        if (objectToMove.transform.position == point2.position)
        {
            currentTarget = point3.position;
        }
        else if(objectToMove.transform.position == point3.position)
        {
            currentTarget = point4.position;
        }

        else if (objectToMove.transform.position == point4.position)
        {
            currentTarget = point1.position;
        }

    }
}
