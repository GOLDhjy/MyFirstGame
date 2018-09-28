using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using UnityEngine.SceneManagement;


/// <summary>
/// 主驱动
/// </summary>
public class Main : MonoBehaviour {
    public static Main _instance;
    public enum state_game:int
    {
        start,
        run,
        gameover,
    }

    private static state_game game_state;

    public state_game Game_state
    {
        get
        {
            return game_state;
        }

        set
        {
            game_state = value;
        }
    }

    // Use this for initialization
    void Start () {
        _instance = this;
        //player = player_state.player_state_instance;
    }
    
	
	// Update is called once per frame
	void Update () {
        if (game_state == state_game.start)
        {
            if(SceneManager.GetActiveScene()!=SceneManager.GetSceneByBuildIndex(0))
            scene_manager.load_scene(0);
            if(Time.timeScale!=1)
            Time.timeScale = 1;
        }
        else if (game_state == state_game.run)
        {
            if (Time.timeScale != 1)
                Time.timeScale = 1;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("upload"))
                scene_manager.load_scene(1);
                //if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("upload"))
                //    StartCoroutine(upload());
        }
        else if(game_state==state_game.gameover)
        {

            Time.timeScale = 0;
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("upload"))
                scene_manager.load_scene("upload");
        }
        


    }
    /// <summary>
    /// 这个协程是没使用的，属于学习写法。
    /// </summary>
    /// <returns></returns>
    public IEnumerator upload()
    {
        Debug.Log("###");
        scene_manager.load_scene("upload");

        yield return null;
        
    }
}
