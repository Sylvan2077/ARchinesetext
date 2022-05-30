using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chognzhi : MonoBehaviour {
    public GameObject plan1;
    public GameObject playjiemian;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void chongzhibutton()
    {
        if (playjiemian.active == true)
        {

            plan1.SetActive(true);
            Debug.Log("重置加一");

        }

    }
}
