using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyData;
/// <summary>
/// 最后一个场景的提交分数脚本
/// </summary>
public class UI_end: MonoBehaviour {
    
    public static UI_end _instance;
    public Canvas post_name;
    public InputField input;
    public Button cancel;
    public Button quit;
    // Use this for initialization
    void Start () {
        Main._instance.Game_state = Main.state_game.gameover;
        _instance = this;
        quit =transform.Find("quit").GetComponent<Button>();
        quit.onClick.AddListener(quit_to_start);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void quit_to_start()
    {
        //player_state.player_state_instance.set_levelcount(1);
        Main._instance.Game_state = Main.state_game.start;
        scene_manager.load_scene(0);
    }
     
    public void show_canvas()
    {
        post_name.enabled = true;
    }
    public void shutdown_canvas()
    {
        //post_name.enabled = false;
        Main._instance.Game_state = Main.state_game.run;

    }
    public void confim()
    {
        name = input.text;
        mydata.md.uprank.player_name = name;
        mydata.md.uprank.player_score = player_state.player_state_instance.get_levelcount().ToString();

        network.send_rank(mydata.md);
        player_state.player_state_instance.set_levelcount(1);
        //post_name.enabled = false;
        Main._instance.Game_state = Main.state_game.run;
        scene_manager.load_scene(player_state.player_state_instance.get_levelcount());

    }
}

