using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Baidu.Aip.Ocr;
using System.IO;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;


public class ocr : MonoBehaviour {

    public GameObject Ocrjiemian;

    //脚本
    public Groundxianshi groundxianshi;
    public interOCR interOCR;

    public RectTransform UIRect;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public Text wenben;
    private Camera arCamera;


    public GameObject saomiaokuang;
    static int m;

    string m1;
    string m2;
    string m3;
    string m4;



    string filename = "";
    byte[] images;

   static   string  ciyu="";

    int limit=800;
    
    const string APP_ID = "14542223";
    const string ApiKey = "zgu9pXFj03WN9XhdxaQDzhdp";
    const string SecretKey = "4e8QG5jn806CMGsNa5GQK6Q4CSolmLGG";

    Ocr client;


    // Use this for initialization
    void Awake()
    {
        client = new Ocr(ApiKey, SecretKey);
        client.Timeout = 60000;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //解决证书问题
    public bool MyRemoteCertificateValidationCallback(System.Object sender,
    X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain,
        // look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid)
                {
                    isOk = false;
                    break;
                }
            }
        }
        return isOk;
    }

    public void kaishishibie()
    {
        if (Ocrjiemian.active == true)
        {

            Debug.Log("开始OCR识别");
            wenben.text = "";
            cameraall2();
            Debug.Log("截图完成");
            OCRs();
        }

    }


    public void OCRs()//OCR
    {
       
       
     

        try
        {
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

            //    result = client.AccurateBasic(image, null);//高精度
            //byte[] image = File.ReadAllBytes(Application.dataPath + "/laohu.jpg");
            //String path = CaptureScreenshot2(rect);
           // if (filename == "") Debug.Log("屏幕读取失败");

            //byte[] image = File.ReadAllBytes(filename);
            //byte[] image = File.ReadAllBytes("E://111.jpg");

            byte[] image = images;
            images = null;
            var options = new Dictionary<string, object>{
        {"language_type", "CHN_ENG"},
        {"detect_direction", "true"},
        {"detect_language", "true"},
        {"probability", "false"}
    };

            var result = client.GeneralBasic(image, options);//普通精度
            string bbb = JsonConvert.SerializeObject(result);
            Debug.Log(result);
            bbb = Zhuanhuan(bbb);
            wenben.enabled = true;
         
            if (bbb == "")
            {
                //wenben.enabled = true;
                wenben.enabled = true;
                wenben.text = "未识别到文字";
                this.Invoke("textdisable", 3.0f);
               
            }
            else
            {
                //wenben.text = bbb;
            }
            Debug.Log("显示内容：" + bbb);
            //wenben.text = bbb;

            Text text1 = button1.transform.Find("Text").GetComponent<Text>();
            Text text2 = button2.transform.Find("Text").GetComponent<Text>();
            Text text3 = button3.transform.Find("Text").GetComponent<Text>();
            Text text4 = button4.transform.Find("Text").GetComponent<Text>();

            char[] m = new char[4];
            for (int i = 0; i < 4; i++)
            {

            }
            char[] cha = bbb.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                if (bbb.Length > i) m[i] = cha[i];
                else break;
            }
            m1 = m[0].ToString();
            m2 = m[1].ToString();
            m3 = m[2].ToString();
            m4 = m[3].ToString();


            text1.text = m1;
            text2.text = m2;
            text3.text = m3;
            text4.text = m4;

        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
    }
    public void putbutton1()
    {
        ciyu =ciyu+ button1.transform.Find("Text").GetComponent<Text>().text;
        wenben.text=ciyu;

      

    }
    public void putbutton2()
    {
        ciyu = ciyu + button2.transform.Find("Text").GetComponent<Text>().text;
        wenben.text = ciyu;
       
    }
    public void putbutton3()
    {

        ciyu = ciyu + button3.transform.Find("Text").GetComponent<Text>().text;
        wenben.text = ciyu;
        
    }
    public void putbutton4()
    {

        ciyu = ciyu + button4.transform.Find("Text").GetComponent<Text>().text;
        wenben.text = ciyu;
       
    }



    public void button5()
    {
        string quedingzi = ciyu;
        ciyu = "";

        wenben.text = "数据库连接...";
        string shahePath2 = "URI=file:" + Application.persistentDataPath + "/" + "hanzi.db";//（这个目录就是手机的沙盒）
        DbAccess db = new DbAccess(shahePath2);
        SqliteDataReader read = db.SelectWhere("hz_200_pinyin", new string[] { "*" }, new string[] { "hz" }, new string[] { "=" }, new string[] {quedingzi});


        //string shahePath2 = "data source = " + Application.dataPath + "/Plugins/Android/assets/" + "hanzi.db";
        //SQLiteHelper sql2 = new SQLiteHelper(shahePath2);

        //SqliteDataReader read = sql2.Select("hz_200", new string[] { "*" }, quedingzi);

        string hz_id = read["hz"].ToString();


        db.CloseSqlConnection();

        wenben.text = hz_id;

        if (hz_id == "")
        {
            wenben.enabled = true;
            wenben.text = "暂无此字信息，请重新选词。";
           // if (wenben.text == "暂无此字信息，请重新选词。") ;
              //  this.Invoke("textdisable", 3.0f);
        }
        else
        {
           wenben.enabled = true;
            wenben.text = "找平面显示";
           // this.Invoke("textdisable", 3.0f);
              
            Groundxianshi.aa = quedingzi;
            groundxianshi.sousuoshow();

            interOCR.groundpyemian();
        }     

    }
    
    //private void textdisable()
    //{
    //    wenben.enabled = false;
    //}

    //int fan = m;
    public static string  groundplay()
    {
        //wenben.text =m.ToString()+"调用时";
        string  fanhui = ciyu;
        ciyu = "";
        return fanhui;

    }







    public static string Zhuanhuan(string zy)
    {
        string s = "", x = zy, sum = "";
        string y = "word";
        int m = 0, n = 0, k = 80;
        for (int i = 0; i < 1;)
        {
            m = x.IndexOf(y, k);
            n = x.IndexOf('"', m + 9);
            if (m == -1)
                break;
            k = m + 1;
            s = x.Substring(m + 8, (n - m - 8));
            sum = sum + s;
        }
        return sum;
    }





    public void cameraall2()
    {
        string destination = "/sdcard/DCIM";
        //if (Directory.Exists(destination))//判断是否存在目录   destination
        //{
        //    Directory.Delete(destination, true);//删除再创建
        //    Directory.CreateDirectory(destination);//如果不存在创建一个
        //}

        //else               //判断是否存在目录   destination
        //{
        //    Directory.CreateDirectory(destination);//如果不存在创建一个
        //}
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
        // filename = Application.dataPath + "/123.png";
       filename = destination + "/123.png";

         cameraall(arCamera, UIRect);
      


        Debug.Log("截图成功" + filename);

        //return ima;
    }
    public void  cameraall(Camera arcamera, RectTransform UIRect)
    {

        Vector3[] corners = new Vector3[4];
        saomiaokuang.GetComponent<RectTransform>().GetWorldCorners(corners);
        foreach (var item in corners)
        {
            Debug.Log(item);
        }

        float x = corners[0].x;
        float y = corners[0].y;

        int width = (int)(UIRect.rect.width);
        int height = (int)(UIRect.rect.height);
        //左下角为原点（0, 0）
        float leftBtmX = UIRect.transform.position.x + UIRect.rect.xMin;
        float leftBtmY = UIRect.transform.position.y + UIRect.rect.yMin;
        //float leftBtmX = 540+ UIRect.rect.xMin;
        //float leftBtmY =1540 + UIRect.rect.yMin;
        //float leftBtmY = 1540 ;


        //wenben.text = leftBtmX.ToString() + "  X+Y  " + leftBtmY.ToString() + (Screen.height - leftBtmY).ToString();
        //Rect rect = new Rect(leftBtmX, leftBtmY, width, height);
        Debug.Log (width);
        Debug.Log(height);

        Debug.Log(leftBtmX);
        Debug.Log(UIRect.transform.position.x);
        Debug.Log(UIRect.rect.xMin);

        Debug.Log(leftBtmY);
        Debug.Log(UIRect.transform.position.y);
        Debug.Log(UIRect.rect.yMin);

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 1);//宽，高，摄像机层级
        arCamera.targetTexture = rt;
        arCamera.Render();

        RenderTexture.active = rt;

        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);
        //截取贴图宽度，高度，贴图纹理，是否使用映射
        //从屏幕读取像素, leftBtmX/leftBtnY 是读取的初始位置,width、height是读取像素的宽度和高度
        texture.ReadPixels(new Rect(x,y , width, height), 0, 0);
        texture.Apply();//Screen.height - leftBtmY - height

        arCamera.targetTexture = null;//截完屏之后吧设置销毁
        RenderTexture.active = null;
        Destroy(rt);

        images = texture.EncodeToJPG();


        int qualityI = 100;
        while ((images.Length / 1024) >= limit)
        {
            qualityI -= 5;
            images = texture.EncodeToJPG(qualityI);
            //            Debug.Log ("当前大小："+b.Length/1000);
        }
        Debug.Log("当前大小：" + images.Length /1024);
        //images = bytess;
        File.WriteAllBytes(filename, images);//按地址把内容存入
        Debug.Log("图片保存成功" + filename);

        //return bytess;
    }

  


    

}
