using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 玩家的移动控制脚本
/// </summary>
public class player : MonoBehaviour {
    Rigidbody2D rid;
    Animator anim;
    float speed_move;
    Vector2 up_force;
    float jumptime;
    Vector2 maxspeed;
    bool isfall;

    void Start () {
        anim = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        anim.SetBool("isair", true);
        up_force = new Vector2(0, 0);
        jumptime = 2;
        maxspeed = new Vector2 (0,10);
        isfall = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && player_state.player_state_instance.Isair == false)
        {
            
            rid.velocity = new Vector2(0, player_state.player_state_instance.Jump_speed);
        }

        //if (Input.GetKey(KeyCode.Space) && player_state.player_state_instance.Isair==false)
        //{
        //    StartCoroutine(jumpppp());
        //    //rid.velocity = Vector2.zero;
           
            
        //}
        anim.SetFloat("jump_speed", rid.velocity.y);
        speed_move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed_move", Mathf.Abs(speed_move));
        //左右转向
        if (speed_move > 0.1)
            transform.localScale = new Vector3(1, 1, 1);
        else if (speed_move < -0.1) 
            transform.localScale= new Vector3(-1, 1, 1);


        transform.position += new Vector3(speed_move*Time.deltaTime*2, 0);
        transform.rotation = new Quaternion(0,0,0,0);

       // player_state.player_state_instance.life_count = 10;

	}

    /// <summary>
    /// 尝试使用协程，这个脚本协程并没有用到，这个协程的功能是按键越久，跳的越高。
    /// </summary>
    /// <returns></returns>
    IEnumerator jumpppp()
    {
        float timer = 0;
        
        while (Input.GetKey(KeyCode.Space) && timer < jumptime )
        {
            if (rid.velocity.y < 0)
                break;
            Debug.Log(timer);
            float lerp_valve = timer / jumptime;
            up_force = Vector2.Lerp(maxspeed, Vector2.zero, lerp_valve);
            Debug.Log(up_force);
            rid.AddForce(up_force);
            timer += Time.deltaTime*5;
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "land")
        {
            player_state.player_state_instance.Isair = false;
            anim.SetBool("isair", false);
            isfall = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "land")
        {
            player_state.player_state_instance.Isair = false;
            anim.SetBool("isair", false);
            isfall = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "land")
        {
            player_state.player_state_instance.Isair = true;
            anim.SetBool("isair", true);
        }
    }

}
