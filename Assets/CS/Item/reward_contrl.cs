using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reward_contrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Main._instance.Game_state = Main.state_game.run;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            //player_state.player_state_instance.set_levelcount(index+1);
            SceneManager.LoadScene(index + 1);
            Destroy(this.gameObject);
        }

    }
}
