using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_run : MonoBehaviour {

    public GameObject dog;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
		
	}
	
	// Update is called once per frame
	void Update () {
        if(dog.transform.position.x>player.transform.position.x)
        {
            Main._instance.Game_state = Main.state_game.gameover;
            scene_manager.Scene_isrun = false;
            Destroy(this);
            // Time.timeScale = 0; 
           // scene_manager.Game_isrun = true;
        }
        else
            dog.transform.position+=new Vector3(0.02f,0,0);
	}
}
