using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour {
    public AudioClip[] myAudoArray;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void audiochoice(int i)
    {
        string audio_path = "yinpin/ma3";
        var audioclip = Resources.Load<AudioClip>(audio_path);

        //AudioSource.PlayClipAtPoint(myAudoArray[i-1], transform.position);
        AudioSource.PlayClipAtPoint(audioclip, transform.position);


    }
    public void shili()
    {
        audiochoice(2);
    }



}
