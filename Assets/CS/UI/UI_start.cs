using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text;
/// <summary>
/// 开始脚本，UI
/// </summary>
public class UI_start : MonoBehaviour {
    public static UI_start _instance;
    public GameObject id_score111;
    public Canvas cav_register;
    public Canvas cav_rank;
    public Canvas login;
    public Canvas cav_start;
    public Button start;
    public Button quit;
    public Button rank;
    public Button confim;
    public Button login1;
    public Button register;
    public Button rig_confim;
    public Button connect;
    public InputField Key;
    public InputField input_register;
    public GameObject panel;
    public GameObject[] ga = new GameObject[12];
    // Use this for initialization

    void Start () {
        Main._instance.Game_state = Main.state_game.start;
        try
        {
            if (!network.clientsocket.Connected)
            {
                login1.enabled = false;
                register.enabled = false;
                connect.enabled = true;
                if (network.Connect())
                {
                    login1.enabled = true;
                    register.enabled = true;
                    connect.enabled = false;
                }
            }
            else
            {
                connect.enabled = false;
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            Debug.Log("连接服务器失败-不能登录");

        }

        login.enabled = true;
        cav_rank.enabled = false;
        cav_start.enabled = false;
        cav_register.enabled = false;
    }

    public void M_connect()
    {
        network.Connect();
    }
    public void M_start()
    {
        Main._instance.Game_state = Main.state_game.run;
        //scene_manager.Scene_isrun = true;
        //this.gameObject.SetActive(false)  ;
    }
    public void M_continue()
    {
        //SceneManager.LoadScene(player_state.player_state_instance.get_levelcount());
        Main._instance.Game_state = Main.state_game.run;
    }
    public void M_quit()
    {
        network.send_close("3");
        network.Closesocket();
        Application.Quit();
    }
    public void M_rank()
    {
        
        cav_rank.enabled = true;
        //confim.enabled = true;
        cav_start.enabled = false;
        //Rank_list.rank_instance.Create_rank();
        create_rank();
        //StartCoroutine(create_rank());

    }
    public void M_confim()
    {
        cav_rank.enabled = false;
        //confim.enabled = false;
        cav_start.enabled = true;
        Rank_list.rank_instance.Delete_rank();
        //StopCoroutine(create_rank());
    }
    public void M_login()
    {
        string key;
        key = Key.text;
        key = key + 2;
        //if(key=="123456")
        try
        {
            network.sendmessage(key);
            if (network.Receivemessage())
            {
                login.enabled = false;
                cav_start.enabled = true;
                // network.send_close("3");
                //network.Closesocket();
            }
            else
            {
                login.enabled = false;
                login.enabled = true;
            }
        }
        catch(Exception e)
        {
            Debug.Log("未连接到服务器");
        }
        //finally
        //{
        //    login.enabled = false;
        //    login.enabled = true;
        //}
    }
    public void M_register()
    {
        login.enabled = false;
        cav_register.enabled = true;
    }
    public void M_reg_confim()
    {
        string key;
        key = input_register.text;
        network.register_send(key);
        if (network.Receivemessage())
        {
            cav_register.enabled = false;
            login.enabled = true;
        }
    }
    public void create_rank()
    {
        //network.Connect();
        network.sendmessage("4");
        StringBuilder sb = new StringBuilder();
        sb= network.Receive_rank();
        if (sb.ToString()!="null")
        {
            //int i;
            //for (i = 0; i < 10; i += 2)
            //{
            //    ga[i] = Instantiate(id_score111,panel.transform.position,Quaternion.identity,panel.transform) as GameObject;
            //    //tt.transform.SetParent(panel.transform);
            //    ga[i].transform.Find("id").GetComponent<Text>().text = re[i].ToString();
            //    ga[i].transform.Find("score").GetComponent<Text>().text = re[i + 1].ToString();
            //}
            Rank_list.rank_instance.Create_rank(sb);
        }
        else
        {
            Debug.Log("，排行榜为空创建排行榜失败");
        }
        //yield return new WaitForSeconds(1f);
    }
}
