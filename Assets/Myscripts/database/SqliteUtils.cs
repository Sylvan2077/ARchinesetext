using UnityEngine;
using System.Collections;
using System.IO;
using Mono.Data.Sqlite;
using System;


public class SqliteUtils : MonoBehaviour
{
    private SqliteConnection Conn;
    private SqliteCommand Cmd;
    private SqliteDataReader Reader;

    //构造函数所需字符串，数据库名字
    public SqliteUtils(string s)
    {
        try
        {
            //构造数据库连接
            String con = "data source = " + Application.dataPath + "/database/" + s + ".db";
            Conn = new SqliteConnection(con);
            //打开数据库
            Conn.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public String Select(String select)
    {
        log();
        Cmd = Conn.CreateCommand();
        Cmd.CommandText = "SELECT * FROM hz_200 where hz='" + select + "'";
        //安卓目录
        //sql = new SQLiteHelper("URI=file:" + Application.persistentDataPath + "/sqlite4unity.db");
        Reader = Cmd.ExecuteReader();
        string s = "";
        while (Reader.Read())
        {
            string hz_id = Reader["hz_id"].ToString();
            string hz = Reader["hz"].ToString();
            string hz_Radical = Reader["hz_Radical"].ToString();
            string hz_Strokes = Reader["hz_Strokes"].ToString();
            string hz_Str_Num = Reader["hz_Str_Num"].ToString();
            string hz_Eng = Reader["hz_Eng"].ToString();
            string hz_Batch = Reader["hz_Batch"].ToString();

            s = hz_id + hz + hz_Radical + hz_Strokes + hz_Str_Num + hz_Eng + hz_Batch;
            Debug.Log(hz_id + hz + hz_Radical + hz_Strokes + hz_Str_Num + hz_Eng + hz_Batch);
        }
        
        return s;
    }

    public void log()
    {
        return;
    }
}
