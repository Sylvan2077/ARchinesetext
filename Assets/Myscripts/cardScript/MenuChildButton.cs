    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuChildButton : MonoBehaviour
{
    //private MeshCollider myColider01;
    //private MeshCollider myColider02;
    //private MeshCollider myColider03;
    //private MeshCollider myColider04;

    public GameObject myCube01;
    public GameObject myCube02;
    public GameObject myCube03;
    public GameObject myCube04;

    public GameObject Button01;
    public GameObject Button02;
    public GameObject Button03;
    public GameObject Button04;

    public GameObject obj;

    private RaycastHit hitInfo;
   // private Animator anim;

    private Tweener tweener01;
    //private RaycastHit hitInfo;
    public void Start()
    {
        //myColider01 = Button01.GetComponent<MeshCollider>();
        //myColider02 = Button02.GetComponent<MeshCollider>();
        //myColider03 = Button03.GetComponent<MeshCollider>();
        //myColider04 = Button04.GetComponent<MeshCollider>();

        //获取动画
        //anim = myCube02.GetComponent<Animator>();
        //播放动画
        //anim.SetBool("myBool", true);
        //anim.SetBool("MyBool", true);

        // Tweener tweener01;

    }
    public void Update()
    {
        //点击鼠标
        OnClick();
        
    }

    void OnClick() {
        if (Input.GetMouseButtonDown(0))
        {
            //定义射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //射线检测
            if (Physics.Raycast(ray, out hitInfo, 20, -1))
            {
                obj.SetActive(true);
                //检测射线碰撞的物体
                switch (hitInfo.collider.gameObject.tag)
                {
                    case "Button1":
                        if (!myCube01.activeSelf)
                        {
                            myCube01.SetActive(true);
                            myCube02.SetActive(false);
                            myCube03.SetActive(false);
                            myCube04.SetActive(false);

                           /// myCube01.transform.DOMoveX(-0.34f, 0.5f);
                            
                            //myCube02.transform.position = new Vector3(1f, 0.3f, 0.259f);
                            //myCube03.transform.position = new Vector3(1f, 0.652f, 0.284f);
                            //myCube04.transform.position = new Vector3(1.409f, 0.662f, 0.284f);

                        }
                        else if(myCube01.activeSelf)
                        {
                            myCube01.SetActive(false);
                            
                            //myCube01.transform.position = new Vector3(1f, 0.662f, 0.284f);
                            //myCube02.transform.position = new Vector3(1f, 0.3f, 0.259f);
                            //myCube03.transform.position = new Vector3(1f, 0.652f, 0.284f);
                            //myCube04.transform.position = new Vector3(1.409f, 0.662f, 0.284f);
                        }
                        break;
                    case "Button2":
                        if (!myCube02.activeSelf)
                        {
                            myCube01.SetActive(false);
                            myCube02.SetActive(true);
                            myCube03.SetActive(false);
                            myCube04.SetActive(false);
                          
                        }
                        else
                        {
                            myCube02.SetActive(false);                          
                        }
                        break;
                    case "Button3":
                        if (!myCube03.activeSelf)
                        {
                            myCube01.SetActive(false);
                            myCube02.SetActive(false);
                            myCube03.SetActive(true);
                            myCube04.SetActive(false);
                          //  myCube03.transform.DOMoveX(-0.072f, 0.5f);
                        }
                        else
                        {
                            myCube03.SetActive(false);                        
                        }
                        break;
                    case "Button4":
                        if (!myCube04.activeSelf)
                        {
                            myCube01.SetActive(false);
                            myCube02.SetActive(false);
                            myCube03.SetActive(false);
                            myCube04.SetActive(true);

                           // myCube04.transform.DOMoveX(-0.35f, 0.5f);
                        }
                        else
                        {
                            myCube04.SetActive(false);
                          
                        }
                        break;
                }     
            }
        }
    }         
}
