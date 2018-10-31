using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformTimerScript : MonoBehaviour {

    public float timeLimit = 3f;
    public float timer;
    private LevelManager lvlManager;
    public TextMesh timerText;
    public PlayerController player;
    private float PlayerscaleX;


    // Use this for initialization
    void Start () {
        lvlManager = FindObjectOfType<LevelManager>();
        timer = timeLimit+1;
        timerText.text = timer.ToString();
        player = FindObjectOfType<PlayerController>();

        PlayerscaleX = player.transform.localScale.x;
        timerText.transform.parent = null;

        if(player.transform.localScale.x < 0)
        {
            timerText.transform.localScale = new Vector3(-timerText.transform.localScale.x, timerText.transform.localScale.y, timerText.transform.localScale.z);
        }

        //Debug.Log(timerText.transform.localScale.x);
    }

    // Update is called once per frame
    void Update() {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }


        if (timer < 0)
        {
            timer = 0;
            timerText.transform.parent = player.transform;
            lvlManager.transformPlayer("base");
        }

        timerText.text = ((int)timer).ToString();



        //if (PlayerscaleX != player.transform.localScale.x)
        //{
        //    if (player.transform.localScale.x < 0)
        //    {
                //timerText.transform.localScale = new Vector3(-timerText.transform.localScale.x, timerText.transform.localScale.y, timerText.transform.localScale.z);
        //    }

        //}
    
        //PlayerscaleX = player.transform.localScale.x;
        timerText.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1.1f, player.transform.position.z);
    }
}
