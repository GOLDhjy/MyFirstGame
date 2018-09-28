using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


/// <summary>
/// 这个脚本主要是留在以后扩展，包括对场景的物体信息存储，比如position等,还有就是场景的自己特有的驱动
/// </summary>
public class scene_manager  {
    private static bool scene_isrun = true;

    public static bool Scene_isrun
    {
        get
        {
            return scene_isrun;
        }

        set
        {
            scene_isrun = value;
        }
    }

    public static void load_scene(int n)
    {
        SceneManager.LoadSceneAsync(n);

        
    }
    public static void load_scene(string n)
    {
        SceneManager.LoadSceneAsync(n);
    }
    public static void load_player()
    {

    }
}
