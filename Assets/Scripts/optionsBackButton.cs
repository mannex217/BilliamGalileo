using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsBackButton : MonoBehaviour {

    public void backToMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
