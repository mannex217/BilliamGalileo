using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsMenuButton : MonoBehaviour {

    public GameObject quitButton, startButton, titleText, optionsButton, optionsMenu;
    public void loadOptions ()
    {
        quitButton.SetActive(false);
        startButton.SetActive(false);
        optionsButton.SetActive(false);
        titleText.SetActive(false);
        optionsMenu.SetActive(true);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
