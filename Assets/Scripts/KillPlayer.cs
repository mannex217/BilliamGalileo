using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    public GameObject gameOverText, restartButton, octupodeEnemy, playerObject, deathBackground, menuButton;


	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.transform.CompareTag("Player"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            playerObject.SetActive(false);
            octupodeEnemy.SetActive(false);
            deathBackground.SetActive(true);
            menuButton.SetActive(true);
        }
   
            
	}
}
