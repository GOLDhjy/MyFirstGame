using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yunti : MonoBehaviour {
    GameObject player;
    Collider2D m_collider2D;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        m_collider2D = transform.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y<transform.transform.position.y)
        {
            m_collider2D.enabled = false;
        }
        else
        {
            m_collider2D.enabled = true;
        }
	}
}
