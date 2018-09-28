using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 角色状态，包括角色的属性
/// </summary>
public class player_state : MonoBehaviour {


    public static player_state player_state_instance;
    bool alive;
    string name;
    int life_count;
    int level_count ;
    int time_value_score ;
    public  GameObject player;
    float jump_speed;
    bool isair;
    Transform initial_state;
    Transform current_state;






    // Use this for initialization
    void Start () {
        set_levelcount(SceneManager.GetActiveScene().buildIndex);
        Initial_state = this.transform;
        Current_state = this.transform;
        Initial_state.position = new Vector3(-2, 0, 0);
        Current_state.position = Initial_state.position;
        player_state_instance = this;
        isair = true;
        alive = true;
        jump_speed = 3;
        //Slevel_count = SceneManager.GetActiveScene().buildIndex;
        //Application.LoadLevel(level_count);
    }

    // Update is called once per frame
    private void Update()
    {
        Current_state.position = transform.position;

	}
    public void set_name(string tmp)
    {
        name = tmp;
    }
    public string get_name()
    {
        return name;
    }
    public bool get_alive()
    {
        return alive;
    }
    public void set_alive(bool tmp)
    {
        alive = tmp;
    }
    public void set_levelcount(int tmp)
    {
        level_count = tmp;
    }
    public int get_levelcount()
    {
        return level_count;
    }
    public void set_score(int tmp)
    {
        time_value_score = tmp;
    }
    public int get_score()
    {
        return time_value_score;
    }

    public float Jump_speed
    {
        get
        {
            return jump_speed;
        }

        set
        {
            jump_speed = value;
        }
    }

    public bool Isair
    {
        get
        {
            return isair;
        }

        set
        {
            isair = value;
        }
    }

    public Transform Initial_state
    {
        get
        {
            return initial_state;
        }

        set
        {
            initial_state = value;
        }
    }

    public Transform Current_state
    {
        get
        {
            return current_state;
        }

        set
        {
            current_state = value;
        }
    }

    public int Life_count
    {
        get
        {
            return life_count;
        }

        set
        {
            life_count = value;
        }
    }
}
