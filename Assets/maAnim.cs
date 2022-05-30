using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maAnim : MonoBehaviour {
    private Animator anim;
     
	// Use this for initialization
	void Start () {
        this.GetComponent<Animator>().SetBool("cycle",true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
