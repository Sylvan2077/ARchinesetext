using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class ceshi : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //string[] aa = new string[10];
        //for (int i = 0; i < 10; i++)
        //{
        //    aa[i]= "";
        //}
        //aa[0] = "nihao";
        //string bb = "sdcad";
        //int count=0;
        //for(int i=0;i<10;i++)
        //{
        //    int ab = aa[i].Length;
        //   if (aa[i]!="")
        //        count++;
        //    else
        //        break;
        //}
        //Debug.Log(aa.Length);
        //Debug.Log( count);
        //Debug.Log(bb.Length);

        string aa = "马";
        string str = "";
        SQLiteHelper sql2 = new SQLiteHelper("hanzi");
        SqliteDataReader read = sql2.Select("hz_200_pinyin", new string[] { "*" }, aa);

        while (read.Read())
        {


            string hz = read["hz"].ToString();
            string hz_pinyin = read["hz_pinyin"].ToString();
            string hz_shiyi = read["hz_shiyi"].ToString();


            str = hz + "\n" + hz_pinyin + "\n" + hz_shiyi;
            Debug.Log("11;" + hz + "," + hz_pinyin + hz_shiyi);
            Debug.Log("22;" + str);



        }
    }
	// Update is called once per frame
	void Update () {
        Debug.Log("update函数");
	}
}
