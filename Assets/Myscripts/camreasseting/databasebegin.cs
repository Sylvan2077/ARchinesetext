using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using Mono.Data.Sqlite;

public class databasebegin : MonoBehaviour {

    // Use this for initialization

   // public Text textshow;
    void Start () {
        Debug.Log("Application.dataPath" + Application.dataPath + "/Plugins/Android/assets/" + "hanzi.db");
        Debug.Log("Application.persistentDataPath" + Application.persistentDataPath);
        Debug.Log(" Application.streamingAssetsPath" + Application.streamingAssetsPath);


        databaseshow2();
       // databaseceshi();


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void databaseshow2()
    {
//#if UNITY_EDITOR//通过路径找到第三方数据库
      
//        string dbpath =Application.streamingAssetsPath + "/hanzi.db";
//        DbAccess db1 = new DbAccess("URI=file:" + dbpath);
//        SqliteDataReader sqReader1 = db1.SelectWhere("hz_200", new string[] { "*" }, new string[] { "hz" }, new string[] { "=" }, new string[] { "五" });
//        string hz1 = sqReader1["hz"].ToString();
//       // textshow.text = hz1;
//        db1.CloseSqlConnection();
//#endif

#if UNITY_ANDROID
        //string pcpath = Application.streamingAssetsPath + "/hanzi.db";
        string appDBPath = Application.persistentDataPath + "/" + "hanzi.db";//（这个目录就是手机的沙盒）
        string wwwpath = "file://" + Application.streamingAssetsPath + "/hanzi.db";
       //File.Copy(pcpath, appDBPath, true);
      //  textshow.text = "数据库复制结束";

       // ReadData(wwwpath,appDBPath);

        WWW loadDB2 = new WWW(Application.streamingAssetsPath + "/hanzi.db");
        while (!loadDB2.isDone) { }
        Debug.Log("数据库字节大小："+loadDB2.bytes.Length);
        //如果已知路径没有地方放数据库，那么我们从Unity中拷贝
        if (!File.Exists(appDBPath))
        {
            FileStream fsDes = File.Create(appDBPath);
            fsDes.Write(loadDB2.bytes, 0, loadDB2.bytes.Length);
            fsDes.Flush();
            fsDes.Close();
           
            //拷贝至规定的地方
           // File.WriteAllBytes(appDBPath, loadDB2.bytes);
        }

        //注意！！！！！！！这行代码的改动
        DbAccess db = new DbAccess("URI=file:" + appDBPath);
        SqliteDataReader sqReader = db.SelectWhere("hz_200", new string[] { "*" }, new string[] { "hz" }, new string[] { "=" }, new string[] { "四" });
        string hz = sqReader["hz"].ToString();
       // textshow.text = hz;
        db.CloseSqlConnection();
#endif
    }
    //public byte[] getFromAssetss(string fileName)
    //{ //android里边读取streamingAsset目录的文件

    //    try
    //    {
    //        //得到资源中的Raw数据流  
    //        InputStream in = getResources().getAssets().open(fileName);

    //        //得到数据的大小  
    //        int length = in.available();

    //        byte[] buffer = new byte[length];          
          
    //        //读取数据  
    //        in.read(buffer);           
    //        //依test.txt的编码类型选择合适的编码，如果不调整会乱码   
    //       // res = EncodingUtils.getString(buffer, "BIG5");   
              
    //        //关闭      
    //        in.close();
    //        return buffer;

    //    }
    //    catch (Exception e)
    //    {
    //        e.printStackTrace();
    //        return null;
    //    }
    //}

   public  IEnumerator ReadData(string path,string appDBPath)
    {
        WWW www = new WWW(path);
        while (!www.isDone) { }
        yield return www;
        Debug.Log(www.bytes.Length);
        while (www.isDone == false)
        {
        //    yield return new WaitForEndOfFrame();
        }
      //  yield return new WaitForSeconds(0.5f);
        File.WriteAllBytes(appDBPath,www.bytes);

        Debug.Log(www.bytes.Length);
        //yield return new WaitForEndOfFrame();
    }


    public void databaseceshi()
    {


        string datastr = "";

#if UNITY_EDITOR//通过路径找到第三方数据库
        string DBPath = Application.streamingAssetsPath + "/hanzi.db";
        SQLiteHelper sql2 = new SQLiteHelper("URI=file:" + DBPath);
        SqliteDataReader read = sql2.Select("hz_200_pinyin", new string[] { "*" }, "十");

        datastr = read["hz"].ToString();

#endif

        if (Application.platform == RuntimePlatform.Android)
        {//
          //  textshow.text = "这里是安卓平台。";

            //将第三方数据库拷贝至Android可找到的地方
            string shahePath2 = Application.persistentDataPath + "/" + "hanzi.db";//（这个目录就是手机的沙盒）
                                                                                 //用www先从Unity中下载到数据库
            WWW loadDB2 = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "/hanzi.db");
            while (!loadDB2.isDone) { }
            //如果已知路径没有地方放数据库，那么我们从Unity中拷贝
            if (!File.Exists(shahePath2))

            {
                //拷贝至规定的地方
                File.WriteAllBytes(shahePath2, loadDB2.bytes);
            }
            else
            {
                //如果在手机沙盒中以存在该文件，可以先删除，再写进去（这样的是保证手机沙盒中的文件不是0字符的空文件，反正不这样写就悲催了）
                File.Delete(shahePath2);
                //WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "location.db"); 
                File.WriteAllBytes(shahePath2, loadDB2.bytes);
            }

            //在这里重新得到db对象。
            SQLiteHelper db2 = new SQLiteHelper("URI=file:" + shahePath2);
            SqliteDataReader read3 = db2.Select("hz_200_pinyin", new string[] { "*" }, "结");

            datastr = read3["hz"].ToString();
        }
      //  textshow.text = datastr;

    }


 
}
