using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public float s;
    public GameObject go;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        go.transform.Rotate(0,0,this.s);
    }

    void getobject(GameObject go)
    {
        this.go = go;
    }
    void getspeed(float s)
    {
        this.s = s;
    }
}
