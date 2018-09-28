using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Text;
using MyData;

/// <summary>
/// 提供对排行榜的功能支持
/// </summary>
public class Rank_list : MonoBehaviour {


   
    const int len = 100;
    public static Rank_list rank_instance;
    public GameObject id_score111;
    public GameObject panel;
    public GameObject [] ga ;
    void Start () {
        ga = new GameObject[12];
        rank_instance = this;
    }
	

    public void Create_rank(StringBuilder tmp)
    {
        mydata.md = JsonUtility.FromJson<mydata>(tmp.ToString());

        mydata.md.myrank.Sort(delegate(mydata.rank_struct a,mydata.rank_struct b)
        {
            return Convert.ToInt32(b.player_score).CompareTo(Convert.ToInt32(a.player_score));
        }
        );
        //for (int a = 0; a < ll / 2; a++)
        //{
        //    for (int b = 0; b < ll / 2; b++)
        //    {
        //        if ((Convert.ToInt32(mydata.md.myrank[a].player_score) > Convert.ToInt32(mydata.md.myrank[b].player_score)))
        //        {
        //            mydata.md.myrank.
        //            t.player_name = n[a].player_name;
        //            t.player_score = n[a].player_score;

        //            n[a].player_name = n[b].player_name;
        //            n[a].player_score = n[b].player_score;

        //            n[b].player_name = t.player_name;
        //            n[b].player_score = t.player_score;
        //        }
        //    }
        //}
        ////List <rank_struct> result =new List<rank_struct>();
        //for (int k = 0; k < 5; k++)
        //    result.Add(n[k]);
        //result.Sort(delegate (rank_struct a, rank_struct b)
        //{

        //    return a.player_score.CompareTo(b.player_score);


        //}
        //);
        //rank_struct [] last= result.ToArray();

        //var query = from item in n orderby item.player_score select item;
        //int k = 0;
        //foreach(var p in query)
        //{
        //    n[k++] = p;
        //}

        //for (i = 0; i < 10; i += 2)
        //{
        //    ga[i] = Instantiate(id_score111, transform.position, Quaternion.identity, transform) as GameObject;
        //    ga[i].transform.SetParent(panel.transform);
        //    ga[i].transform.Find("id").GetComponent<Text>().text = re[i].ToString();
        //    ga[i].transform.Find("score").GetComponent<Text>().text = re[i + 1].ToString();
        //}
        int num_rank = mydata.md.myrank.Count > 5 ? 5 : mydata.md.myrank.Count;
        for (int i = 0; i < num_rank; i++)
        {
            ga[i] = Instantiate(id_score111, transform.position, Quaternion.identity, transform) as GameObject;
            ga[i].transform.SetParent(panel.transform);
            ga[i].transform.Find("id").GetComponent<Text>().text = mydata.md.myrank[i].player_name;
            ga[i].transform.Find("score").GetComponent<Text>().text = mydata.md.myrank[i].player_score;
        }
    }
    public void Delete_rank()
    {
        for(int i=0;i<10;i++)
        {
            Destroy(ga[i]);
        }
    }
}
