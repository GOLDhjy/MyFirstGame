using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// 摄像机控制，跟随角色
/// </summary>
public class camera_flow : MonoBehaviour {

    //public Transform player;
    public GameObject player2;
    Vector3 pos_c;
    Vector3 position;

    public string name;
    // Use this for initialization
    void Start () {
        //player = transform.Find("player");
        //transform.position = new Vector3(0, 0, -10);
        player2 = GameObject.Find("player");
        pos_c = player2.transform.position - transform.position;

        
	}

    // Update is called once per frame
    private void Update()
    {
        //print(player2.transform.position);
        position = new Vector3(player2.transform.position.x - pos_c.x, transform.position.y, transform.position.z);
        transform.position = position;

	}
}
