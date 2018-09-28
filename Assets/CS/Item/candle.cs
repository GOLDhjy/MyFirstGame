using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 蜡烛的脚本,包括他的动画
/// </summary>
public class candle : MonoBehaviour {

    bool isfire;
    Animator anim;
    private void Start()
    {
        isfire = false;
        anim = GetComponent<Animator>();
        anim.SetBool("isfire", isfire);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isfire = true;
            anim.SetBool("isfire", isfire);
        }
    }
}
