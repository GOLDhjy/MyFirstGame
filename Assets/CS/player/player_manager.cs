using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -5 )
        {
            player_state.player_state_instance.Life_count--;
            player_state.player_state_instance.set_alive(false);
            scene_manager.Scene_isrun = false;
            Main._instance.Game_state = Main.state_game.gameover;

            //network.Connect();

        }

    }
}
