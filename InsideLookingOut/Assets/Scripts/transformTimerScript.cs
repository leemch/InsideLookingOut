using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformTimerScript : MonoBehaviour {

    public float timeLimit = 3f;
    public float timer;
    private LevelManager lvlManager;
    public TextMesh timerText;


    // Use this for initialization
    void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
        timer = timeLimit+1;
        timerText.text = timer.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        

        if(timer < 0)
        {
            timer = 0;
            lvlManager.transformPlayer("base");
        }
        
        timerText.text = ((int)timer).ToString();

        //timerText.transform.position = gameObject.transform.position;
    }
}
