using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using Mono.Data.Sqlite;
public class showmoxing : MonoBehaviour
{
    public static string aa;
    //显示面板
    public GameObject jibenxinxi;
    public GameObject shiyi;
    //虚拟按钮
    public GameObject Button01;
    public AudioClip duyin;
    private RaycastHit hitInfo;

    // Use this for initialization
    void Start()
    {
        aa = "西";
        sousuoshow();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sousuoshow()
    {
        string str = "";
        SQLiteHelper sql2 = new SQLiteHelper("hanzi");
        SqliteDataReader read = sql2.Select("hz_200", new string[] { "*" }, aa);
        aa = "";
        while (read.Read())
        {
            string hz_id = read["hz_id"].ToString();
            string hz = read["hz"].ToString();
            string hz_Radical = read["hz_Radical"].ToString();
            string hz_Strokes = read["hz_Strokes"].ToString();
            string hz_Str_Num = read["hz_Str_Num"].ToString();
            string hz_Eng = read["hz_Eng"].ToString();
            string hz_Batch = read["hz_Batch"].ToString();

            str = hz + "\t" + "部首：" + hz_Radical + "\n" + "笔画：" + hz_Str_Num + "\n" + "笔顺：" + hz_Strokes + "\n";
            Debug.Log(hz_id + "," + hz + hz_Radical + "," + hz_Strokes + "," + hz_Str_Num + "," + hz_Eng + "," + hz_Batch);
            Debug.Log(str);
            jibenxinxi.GetComponent<TextMesh>().text = hz;
        }

        SqliteDataReader read2 = sql2.Select("hz_200_pinyin", new string[] { "*" }, aa);
        aa = "";
        while (read2.Read())
        {
            string hz = read["hz"].ToString();
            string hz_pinyin = read["hz"].ToString();
            string hz_shiyi = read["hz_shiyi"].ToString();


            str = hz_shiyi;
            Debug.Log("11;" + hz + "," + hz_pinyin + hz_shiyi);
            Debug.Log("22;" + str);

            shiyi.GetComponent<TextMesh>().text = hz_shiyi;
        }
    }
        public void xunianniu()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //定义射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //射线检测
                if (Physics.Raycast(ray, out hitInfo, 20, -1))
                {

                    //检测射线碰撞的物体
                    switch (hitInfo.collider.gameObject.tag)
                    {
                        case "Button1":            
                            AudioSource.PlayClipAtPoint(duyin, transform.position);                       
                            break;

                    }
                
            }
        }
    }
 
    
   




   

   
}
