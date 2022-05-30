using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour {
    public GameObject Gamecanvas_1;
    public GameObject Gamecanvas_2;

    public void StartButton() {
        //Application.LoadLevel("02_GameScene");
        Gamecanvas_1.SetActive(false);
        Gamecanvas_2.SetActive(true);
    }

    public void BackButton()
    {
        Gamecanvas_1.SetActive(true);
        Gamecanvas_2.SetActive(false);
    }

    public void quitButton() {
        Application.Quit();
    }
}
