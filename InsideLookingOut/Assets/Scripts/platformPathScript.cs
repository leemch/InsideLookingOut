using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformPathScript : MonoBehaviour {

    public LevelManager lvlManager;
    public GameObject objectToMove;
    public Transform[] points;
    public float moveSpeed;
    private Vector3 currentTarget;
    platformScript childScript;

    

    public bool active;

    int numPoints;

    int index;

	// Use this for initialization
	void Start () {
        index = 0;
        numPoints = points.Length;
        currentTarget = points[1].position;
        active = false;
        childScript = gameObject.GetComponentInChildren<platformScript>();

        lvlManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {


        if (active)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

            if (index < (numPoints-1))
            {
                if (objectToMove.transform.position == currentTarget)
                {
                    currentTarget = points[index + 1].position;
                    index += 1;
                }
            }


            if (lvlManager.isDead)
            {
                reset();
            }


        }

    }

    public void reset()
    {
        active = false;
        objectToMove.transform.position = points[0].position;
        childScript.playerTouched = false ;
        index = 0;
        currentTarget = points[1].position;
    }




}
