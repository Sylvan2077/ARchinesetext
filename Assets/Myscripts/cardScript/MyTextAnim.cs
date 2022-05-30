using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Vuforia;

public class MyTextAnim : MonoBehaviour
{

    // 1.引入命名空间
    // 2.定义属性
    // 3.将当前的text 给属性赋值
    // 使用 DOColor 
    // DOFade 渐影渐变
    protected TrackableBehaviour mTrackableBehaviour;
    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {       
        if (this.gameObject.activeSelf) {
            //text.DOColor(Color.red, 7);            
           Tweener tweener = text.DOFade(0, 2);
           tweener.OnComplete(End);
           
        }               
    }
    public void End() {
        text.DOFade(1, 0.1f);
        this.gameObject.SetActive(false);
    }
}
