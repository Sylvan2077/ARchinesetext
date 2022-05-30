using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChange : MonoBehaviour {
    public GameObject model1;
    public GameObject model2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void modelchange()
    {
        if (model1.activeInHierarchy)
        {
            Model2show();
        }
        else
            Model1show();
    }
    public void Model1show()
    {
        model1.SetActive(true);
        model2.SetActive(false);
    }

    public void Model2show()
    {
        model2.SetActive(true);
        model1.SetActive(false);
    }


}
