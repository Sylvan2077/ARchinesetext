using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LineAnimin : MonoBehaviour {

    //public GameObject Myline;
    //public GameObject gameCanvas;
    int a = 100;
    int b;
    //float myTime;

    Tweener tweener;
    private void Start()
    {
        //myTime = Myline.Time.timeSinceLevelLoad;
        tweener = this.transform.DOLocalMoveY(-600, 2f);
        tweener.SetLoops(a);
       
    }
    // Use this for initialization

    private void Update()
    {
      
    }

}
