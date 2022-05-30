using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



namespace Vuforia
{
    public class cameraseting : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

            //回调函数
            var vuforia = VuforiaARController.Instance;
            vuforia.RegisterVuforiaStartedCallback(onVuforiaStarted);//当程序开始时执行的函数
            vuforia.RegisterOnPauseCallback(OnPuased);//当程序结束或暂停时执行的函数;

            //获取设置当前屏幕分辩率  
            Resolution[] resolutions = Screen.resolutions;
            //设置当前分辨率  
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);

            Screen.fullScreen = true;  //设置成全屏,  


        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))//判断是否触摸了屏幕
            {


                if (Input.touchCount == 1)//touchCount判断几根手指碰到屏幕
                {

                    if (Input.GetTouch(0).tapCount == 2)//判断是否双击
                    {
                        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
                    }


                }

            }
        }

        private void onVuforiaStarted()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }

        private void OnPuased(bool ispaused)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }

        private void database()
        {
#if UNITY_ANDROID
            //将第三方数据库拷贝至Android可找到的地方
            string appDBPath = Application.persistentDataPath + "/" + "location.db";//（这个目录就是手机的沙盒）
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/Plugins/" + "hanzi.db");
            //如果已知路径没有地方放数据库，那么我们从Unity中拷贝
            if (!File.Exists(appDBPath))

            {
                //用www先从Unity中下载到数据库
                // WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "location.db");
                //拷贝至规定的地方
                File.WriteAllBytes(appDBPath, loadDB.bytes);
            }
            else
            {
                //如果在手机沙盒中以存在该文件，可以先删除，再写进去（这样的是保证手机沙盒中的文件不是0字符的空文件，反正不这样写就悲催了）
                File.Delete(appDBPath);
                //WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "location.db");
                File.WriteAllBytes(appDBPath, loadDB.bytes);
            }
#endif
        }
    }
}
