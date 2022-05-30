using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchplay : MonoBehaviour {
    Vector2 oldpos1;
    Vector2 oldpos2;
    float xSpeed = 150.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))//是否触摸屏幕
        {
            if (Input.touchCount == 1)//是否单指触摸
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)//第一个触摸的手指的状态   是滑动
                {
                    transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * -xSpeed * Time.deltaTime*0.5f, Space.World);
                    //转动  ：速度，围绕坐标
                }
            }
        }

        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector2 temPos1 = Input.GetTouch(0).position;
                Vector2 temPos2 = Input.GetTouch(1).position;
                if (isElarge(oldpos1, oldpos2, temPos1, temPos2))
                {//放大
                    float oldscale = transform.localScale.x;
                    float newscale = oldscale * 1.025f;

                    transform.localScale = new Vector3(newscale, newscale, newscale);

                }
                else
                {
                    float oldscale = transform.localScale.x;
                    float newscale = oldscale / 1.025f;

                    transform.localScale = new Vector3(newscale, newscale, newscale);

                }
                oldpos1 = temPos1;
                oldpos2 = temPos2;
            }
        }
    }

    bool isElarge(Vector2 op1, Vector2 op2, Vector2 np1, Vector2 np2)
    {
        float length1 = Mathf.Sqrt((op1.x - op2.x) * (op1.x - op2.x) + (op1.y - op2.y) * (op1.y - op2.y));
        float length2 = Mathf.Sqrt((np1.x - np2.x) * (np1.x - np2.x) + (np1.y - np2.y) * (np1.y - np2.y));
        if (length1 < length2)//放大
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}
