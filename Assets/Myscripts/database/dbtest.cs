using UnityEngine;
using System.Collections;
using System.IO;
using Mono.Data.Sqlite;

public class dbtest : MonoBehaviour
{
    

    //private SqliteUtils sql;    
    void Start()
    {
      
        //sql = new SqliteUtils("hanzi");
        //   string s =sql.Select("天");
        SQLiteHelper sql2 = new SQLiteHelper("hanzi");

        SqliteDataReader read = sql2.Select("hz_200", new string[] { "*" }, "十");
        while (read.Read())
        {

            //表里就这些数据，你选一点试试能不能连接
            string hz_id = read["hz_id"].ToString();
            string hz = read["hz"].ToString();
            string hz_Radical = read["hz_Radical"].ToString();
            string hz_Strokes = read["hz_Strokes"].ToString();
            string hz_Str_Num = read["hz_Str_Num"].ToString();
            string hz_Eng = read["hz_Eng"].ToString();
            string hz_Batch = read["hz_Batch"].ToString();
            Debug.Log(hz_id +","+ hz + hz_Radical + "," + hz_Strokes + "," + hz_Str_Num + "," + hz_Eng + "," + hz_Batch);
        }
        sql2.CloseConnection();                                      
    }
}
