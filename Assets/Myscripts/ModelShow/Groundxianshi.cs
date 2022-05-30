using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using Mono.Data.Sqlite;
using DG.Tweening;

public class Groundxianshi : MonoBehaviour
{
    //脚本
    public new audio audio;

    //按钮
    //public GameObject Button01;
    public GameObject functionbutton;
    public GameObject outbutton;
    public GameObject inbutton;

    public RectTransform functionall;
    // public AudioClip duyin;

    //显示面板
    public GameObject ziti;
    public GameObject pinyin;
    public GameObject shiyi;
    public GameObject model;

    public GameObject mode2_jibenxinxi;
    public GameObject mode2_shiyi;
    public GameObject model2_model;
    //private Text ziti2;
    //private Text pinyin2;
    //private Text shiyi2;


    public Text textshow;


    //变量
    public static string aa;
    int hanziID=3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
//    public void SQlist_android()
//    {


//   //   #if UNITY_EDITOR//通过路径找到第三方数据库
//        string appDBPath = Application.streamingAssetsPath + "/loadDB.db";
//        DbAccess db = new DbAccess("URI=file:" + appDBPath);
//     //如果运行在Android设备中
//  // #elif UNITY_ANDROID
 
////将第三方数据库拷贝至Android可找到的地方
//string appDBPath = Application.persistentDataPath + "/" + "location.db";//（这个目录就是手机的沙盒）
 
////如果已知路径没有地方放数据库，那么我们从Unity中拷贝
//if(!File.Exists(appDBPath))
 
//    {
////用www先从Unity中下载到数据库
//   WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "location.db"); 
////拷贝至规定的地方
//   File.WriteAllBytes(appDBPath, loadDB.bytes);
//    }
//        else
//        {
//            //如果在手机沙盒中以存在该文件，可以先删除，再写进去（这样的是保证手机沙盒中的文件不是0字符的空文件，反正不这样写就悲催了）
//            File.Delete(appDBPath, loadDB.bytes);
//            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "location.db"); 
//            File.WriteAllBytes(appDBPath, loadDB.bytes);
//        }
 
////在这里重新得到db对象。
//DbAccess db = new DbAccess("URI=file:" + appDBPath);



//}

    
    public void sousuoshow()
    {
        //"data source = " + 

        Debug.Log("模型信息写入");
        string str = "";
        string shiyineirong="";
        string shahePath2 = "URI=file:" + Application.persistentDataPath + "/" + "hanzi.db";//（这个目录就是手机的沙盒）



        DbAccess db = new DbAccess(shahePath2);
        SqliteDataReader read = db.SelectWhere("hz_200_pinyin", new string[] { "*" }, new string[] { "hz" }, new string[] { "=" }, new string[] { aa });

       // SqliteDataReader read2 = sql2.Select("hz_200_pinyin", new string[] { "*" }, aa);
        //SQLiteHelper sql3 = new SQLiteHelper("hanzi");
        //SqliteDataReader read2 = sql2.Select("hz_200", new string[] { "*" }, aa);

        //aa = "";
        while (read.Read())
        {


            string hz = read["hz"].ToString();
          
            string hz_pinyin = read["hz_pinyin"].ToString();
            string hz_shiyi = read["hz_shiyi"].ToString();
            shiyineirong = hz_shiyi;

            str = hz + "\n" + hz_pinyin + "\n" + huanhang(hz_shiyi);
            Debug.Log("11;" + hz + "," + hz_pinyin + hz_shiyi);
            Debug.Log("22;" + str);

            ziti.GetComponent<TextMesh>().text = hz;
            pinyin.GetComponent<TextMesh>().text = hz_pinyin;
            shiyi.GetComponent<TextMesh>().text = huanhang(hz_shiyi);

            string str1 = hz + "\n拼音："+hz_pinyin;
            string str2 = huanhang(hz_shiyi);
             mode2_jibenxinxi.GetComponent<TextMesh>().text = str1;
             mode2_shiyi.GetComponent<TextMesh>().text = str2;

            textshow.text = str1 + str2;


        }


        hanziModel_show(aa);

        db.CloseSqlConnection();
    }
    
//    1.最小的正整数。见〖数字〗。
//2.表示同一：咱们是～家人。你们～路走。这不是～码事。
//3.表示另一：番茄～名西红柿。
//4.表示整个；全：～冬。～生。～路平安。～屋子人。～身的汗。
//5.表示专一：～心～意。
//6.表示动作是一次，或表示动作是短暂的，或表示动作是试试的。a）用在重叠的动词（多为单音）中间：歇～歇。笑～笑。让我闻～闻。b）用在动词之后，动量词之前：笑～声。看～眼。让我们商量～下。
//7.用在动词或动量词前面，表示先做某个动作（下文说明动作结果）：～跳跳了过去。～脚把它踢开。他在旁边～站，再也不说什么。
//8.与“就”配合，表示两个动作紧接着发生：～请就来。～说就明白了。
//9.一旦；一经：～失足成千古恨。
//10.“一”字单用或在一词一句末尾念阴平，如“十一、一一得一”，在去声字前念阳平，如“一半、一共”，在阴平、阳平、上声字前念去声，如“一天、一年、一点”。本词典为简便起见，条目中的“一”字，都注阴平。
//11.我国民族音乐音阶上的一级，乐谱上用作记音符号，相当于简谱的“”。见〖工尺〗。

    public void hanziModel_show(string hzb)
    {
        string model_path = "hanzimodel/"+hzb;
       //模型1
        GameObject modelc = Resources.Load(model_path) as GameObject;
        GameObject modeld = Instantiate(modelc);
        if (modelc == null)
            Debug.Log("不存在模型资源");
    
        modeld.transform.parent = model.transform;

        modeld.transform.localScale = Vector3.one;
        modeld.transform.localPosition = Vector3.zero;
        modeld.transform.localEulerAngles = Vector3.zero;

        //模型2
        GameObject modelc2 = Resources.Load(model_path) as GameObject;
        GameObject modeld2 = Instantiate(modelc2);
        if (modelc2 == null)
            Debug.Log("不存在模型资源");

        modeld2.transform.parent = model2_model.transform;

        modeld2.transform.localScale = Vector3.one;
        modeld2.transform.localPosition = Vector3.zero;
        modeld2.transform.localEulerAngles = Vector3.zero;

    }

    public void sousuoshow2()
    {
        //ocr shibie = new ocr();
        // Debug.Log(a+ "序号");
        string str = "";
        SQLiteHelper sql2 = new SQLiteHelper("hanzi");

        SqliteDataReader read = sql2.Select("hz_200", new string[] { "*" }, aa);
        aa = "";
        while (read.Read())
        {

            //表里就这些数据，你选一点试试能不能连接
            string hz_id = read["hz_id"].ToString();

            hanziID = int.Parse(hz_id);
            string hz = read["hz"].ToString();
            string hz_Radical = read["hz_Radical"].ToString();
            string hz_Strokes = read["hz_Strokes"].ToString();
            string hz_Str_Num = read["hz_Str_Num"].ToString();
            string hz_Eng = read["hz_Eng"].ToString();
            string hz_Batch = read["hz_Batch"].ToString();

            str = hz_id + "\n" + hz + hz_Radical + "\n" + hz_Strokes + "\n" + hz_Str_Num + "\n" + hz_Eng + "\n" + hz_Batch;
            Debug.Log(hz_id + "," + hz + hz_Radical + "," + hz_Strokes + "," + hz_Str_Num + "," + hz_Eng + "," + hz_Batch);
            Debug.Log(str);
        }
        textshow.text = str;
        
        //string path = Application.dataPath + "/database/" + a + ".txt";
        //Debug.Log(path + "路径");
        //string sin = File.ReadAllText(path);//读取所有行作为一个字符串
        //string aa = "五nwun横、竖、横折、横、n1.四加一后所得的数目。见〖数字〗。n2.姓。/ n3我国民族音乐音阶上的一级，乐谱上用作记音符号。相当于简谱的“6”。见〖工尺〗。n";
        //string sin = mianbanshow(path);
        //sin = sin.Replace("n","\n");          

        //wen.GetComponent<TextMesh>().text = str;
        //wen2.GetComponent<TextMesh>().text = str;

    }
    //private string huanhang2(string str)//十字一换行
    //{
    //    int k = 0;
   
    //    string[] strs = str.Split();
        
    //    for (int i = 0; i < strs.Length; i++)
    //    {
    //        k++;
    //        if (k == 10)
    //        {
    //            str = str.Insert(i, "\n");
    //            k = 0;
               
    //        }
    //    }
      
    //    return str;
    //}

    public static string huanhang(string input)
    {
        for (int i = 10; i < input.Length; i += 10 + 1)
            input = input.Insert(i, "\n");
        return input;
    }


    private void textdisable()
    {
        textshow.enabled = false;
    }


    private RaycastHit hitInfo;

    void OnClick()
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
                    case "duyin":                      
                            int ciID = hanziID % 4 + 1;
                            audio.audiochoice(ciID);
                        break;

                }
            }
        }
    }









    public void outButton()
    {
        //functionbutton.SetActive(true);

        functionall.DOLocalMoveX(18.0f, 0.5f);
        inbutton.SetActive(true);
        outbutton.SetActive(false);
    }
    public void inButton()
    {
        // functionbutton.SetActive(false);
        functionall.DOLocalMoveX(146.0f, 0.5f);

        inbutton.SetActive(false);
        outbutton.SetActive(true);
    }


    public void Model_show_Button()
    {
        shiyi.SetActive(false);
        model.SetActive(true);


    }
    public void audio_Button()
    {
        int ciID = hanziID % 4 + 1;
        audio.audiochoice(ciID);
        Debug.Log("音频播放序号："+ciID+hanziID);
    }
    public void shiyi_Button()
    {
        shiyi.SetActive(true);
        model.SetActive(false);

    }
}
