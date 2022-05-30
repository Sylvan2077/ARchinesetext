using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using Mono.Data.Sqlite;




public class interOCR : MonoBehaviour {

    //按钮
    public GameObject camerbutton;
    //脚本
    public Groundxianshi groundshow;
  
    //主界面
    public GameObject beijing;
    public GameObject main;
    public GameObject fumain;
    public GameObject wo;
    public GameObject Ocrjiemain;
    public GameObject groundp;

    //wode界面
    public GameObject zhuyemian;
    public GameObject banbenyemian;
    public GameObject hanzibenyemian;
    public GameObject lishijiemian;

    public Text historyttext;
    public InputField Input_sousuo;


    //十次历史记录按钮
    public Button[] historysbut;



    //变量
    string[] history=new string[10];
    
    string[] allhistory= new string[5000];
    // Use this for initialization
    //GameController g;


   

    void Start() {
        main.SetActive(true);
        fumain.SetActive(false);
        wo.SetActive(false);
        Ocrjiemain.SetActive(false);
        groundp.SetActive(false);

        //GameObject go = new GameObject();
        //go.AddComponent<Groundxianshi>();
        //groundshow = (Groundxianshi)go.GetComponent(typeof(Groundxianshi));



    }

    // Update is called once per frame
    void Update() {


    }


    //页面转换
    
    public void card()
    {
        SceneManager.LoadScene("card");
    }
  


    //主页面按钮。
    public void zidianbutton()   //字典主页面
    {
        camerbutton.SetActive(true);
        groundp.SetActive(false);
        main.SetActive(true);
        fumain.SetActive(false);
        wo.SetActive(false);
        Ocrjiemain.SetActive(false);
        beijing.SetActive(true);
    }

    public void wodebutton()   //我的  页面
    {
        zhuyemian.SetActive(true);
        hanzibenyemian.SetActive(false);
        lishijiemian.SetActive(false);
        banbenyemian.SetActive(false);

        camerbutton.SetActive(true);
        groundp.SetActive(false);
        main.SetActive(false);
        fumain.SetActive(false);
        wo.SetActive(true);
        Ocrjiemain.SetActive(false);
        beijing.SetActive(true);
    }

    public void xiangjibutton()   //OCR识别界面
    {

        if(groundp.active!=true && Ocrjiemain.active!=true)
        {
            // camerbutton.SetActive(false);
            groundp.SetActive(false);
            main.SetActive(false);
            fumain.SetActive(false);
            wo.SetActive(false);
            Ocrjiemain.SetActive(true);
            beijing.SetActive(false);
        }


    }

    public void shurukuangbutton()     //进入文字输入框界面
    {
        //camerbutton.SetActive(true);
        groundp.SetActive(false);
        main.SetActive(false);
        fumain.SetActive(true);
        wo.SetActive(false);
        Ocrjiemain.SetActive(false);
        beijing.SetActive(true);
    }


    public void groundpyemian()     //进入模型展示框界面
    {
        //camerbutton.SetActive(false);
        main.SetActive(false);
            fumain.SetActive(false);
            wo.SetActive(false);
            Ocrjiemain.SetActive(false);
            beijing.SetActive(false);
           groundp.SetActive(true);
    }
    //副主页面的输入框
    public void sousuobutton()
    {
        
        string sousuoci = Input_sousuo.text;
        Input_sousuo.text = "";

        string shahePath2 = "URI=file:" + Application.persistentDataPath + "/" + "hanzi.db";//（这个目录就是手机的沙盒）
        DbAccess db = new DbAccess(shahePath2);
        SqliteDataReader read = db.SelectWhere("hz_200_pinyin", new string[] { "*" }, new string[] { "hz" }, new string[] { "=" }, new string[] { sousuoci});

        //string shahePath2 ="data source = " + Application.dataPath + "/Plugins/Android/assets/" + "hanzi.db";
        //SQLiteHelper sql2 = new SQLiteHelper(shahePath2);

        //SqliteDataReader read = sql2.Select("hz_200", new string[] { "*" }, sousuoci);

        string hz_id = read["hz"].ToString();

        db.CloseSqlConnection();
        if (hz_id == "")
        {
            Input_sousuo.placeholder.GetComponent<Text>().text = "暂无此字信息，请重新选词";
            //wenben.text = "暂无此字信息，请重新选词。";
            //if (wenben.text == "暂无此字信息，请重新选词。")
            //    this.Invoke("textdisable", 3.0f);
            Debug.Log("搜索失败");
        }
        else
        {
            Groundxianshi.aa = sousuoci;
            Debug.Log("1");
            groundshow.sousuoshow();
            Debug.Log("2");
            groundpyemian();
            Debug.Log("搜索成功");
        }

            //groundp.GetComponent<Groundxianshi>().aa=sousuoci;
           

        string[] history2= new string[10];
        for (int i = 0; i < 10; i++)
        {
            history[i] = "";
            history2[i] = "";
        }
        history2[0] = sousuoci;

        //总历史记录
        int count=0;
        for (int i = 0; i < 5000; i++)
        {
            allhistory[i] = "";
        }


        for (int m = 0; m < allhistory.Length-5; m++)
        {
            if (allhistory[m] != "")
            {
                count++;
                if (count > 4950)
                    break;
            }
            else
                break;
          
        }
        for (int n =count +1; n>0; n--)
        {
            allhistory[n] = allhistory[n- 1];
            if (n > 5000)
                break;
        }
        allhistory[0] = sousuoci;
     //十次不重复的历史
        for (int i=0; i < history.Length; i++)
        {
            count++;
            if (history[i] == sousuoci)
                count++;
            history2[i + 1] = history[count];
            if (history2.Length >=10)
                break;
        }
        for (int k = 0; k < history2.Length; k++)
        {
            history[k] = history2[k];
            Text historytext=historysbut[k].transform.Find("Text").GetComponent<Text>();
            historytext.text = history[k];
        }
        for (int i = 0; i < 10; i++)
        {
            if (history[i] != "")
                historysbut[i].enabled = true;
        } 
    }




    //我的信息窗口
    public void sousuohistory()
    {
        zhuyemian.SetActive(false);
        banbenyemian.SetActive(false);
        lishijiemian.SetActive(true);
        hanzibenyemian.SetActive(false);
        string history_show="";
        for (int i = 0; i < allhistory.Length; i++)
        {
            if (allhistory[i] != "")
                history_show += allhistory[i]+"/n";
            else
                break;
        }
        historyttext.text = history_show;
    }
    public void hanziben()
    {
        zhuyemian.SetActive(false);
        banbenyemian.SetActive(false);
        lishijiemian.SetActive(false);
        hanzibenyemian.SetActive(true);
    }
    public void Versioninformation()
    {
        zhuyemian.SetActive(false);
        banbenyemian.SetActive(true);
        lishijiemian.SetActive(false);
        hanzibenyemian.SetActive(false);
    }



    //十次历史记录按钮
    //public void historybutton1()
    //{
    //    string hsousuoci = history[0];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");

    //    groundpyemian();
    //}
    //public void historybutton2()
    //{
    //    string hsousuoci = history[1];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton3()
    //{
    //    string hsousuoci = history[2];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton4()
    //{
    //    string hsousuoci = history[3];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton5()
    //{
    //    string hsousuoci = history[4];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton6()
    //{
    //    string hsousuoci = history[5];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton7()
    //{
    //    string hsousuoci = history[6];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton8()
    //{
    //    string hsousuoci = history[7];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton9()
    //{
    //    string hsousuoci = history[8];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}
    //public void historybutton10()
    //{
    //    string hsousuoci = history[9];
    //    Groundxianshi.aa = hsousuoci;
    //    groundxianshi.sousuoshow();
    //    if (hsousuoci == "")
    //        Debug.Log("没有查找信息");
    //    groundpyemian();
    //}

}
