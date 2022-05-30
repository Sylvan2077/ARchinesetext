using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButton : MonoBehaviour
{
    private MeshCollider myColider;

    public GameObject myMenuButton;
    public GameObject myMenuChild;

    public Transform Button01;
    public Transform Button02;
    public Transform Button03;
    public Transform Button04;

    public GameObject line1;
    //public GameObject line2;
    //public GameObject line3;
    //public GameObject line4;

    public Transform line;

    
    private RaycastHit hitInfo;


    
    //private RaycastHit hitInfo;
    public void Start()
    {
        myColider = myMenuButton.GetComponent<MeshCollider>();
    }
    public void Update()
    {
        //点击鼠标
        OnClick();
    }

    private void OnClick() {
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
                  
                    case "MainButton":
                        if (!myMenuChild.activeSelf)
                        {
                            myMenuChild.SetActive(true);

                            line.DOScaleY(0.6296607f, 0.3f);
                            line.DOLocalMoveY(-1.43f,0.3f);

                            Button01.DOLocalMoveY(-0.612f, 0.3f);
                            Button02.DOLocalMoveY(-1.06f, 0.4f);
                            Button03.DOLocalMoveY(-1.505f, 0.5f);
                            Button04.DOLocalMoveY(-1.962f, 0.6f);

                            //Button01.DOPlay();
                            //Button02.DOPlay();
                            //Button03.DOPlay();
                            //Button04.DOPlay();
                        }
                        else if(myMenuChild.activeSelf)
                        {
                            myMenuChild.SetActive(false);

                            
                            Button01.DOLocalMoveY(-2.511f, 0.2f);
                            Button02.DOLocalMoveY(-2.496f, 0.3f);
                            Button03.DOLocalMoveY(-2.496f, 0.3f);
                            Button04.DOLocalMoveY(-2.496f, 0.3f);

                            line.DOScaleY(0, 0.1f);
                            line.DOLocalMoveY(-2.4868f, 0.1f);

                            line1.SetActive(false);

                        }
                        break;

                   
                }     
            }
        }
    }         
}
