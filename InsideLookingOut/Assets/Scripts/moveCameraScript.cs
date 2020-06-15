using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCameraScript : MonoBehaviour {


    public GameObject cam;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y-10f, cam.transform.position.z);
        }
    }
}
