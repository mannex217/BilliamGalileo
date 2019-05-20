using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelComplete : MonoBehaviour
{

    public GameObject player;
    public GameManager gameManager;
    public bool ifTouching; 





    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            StartCoroutine(Example());
        }
    }


    IEnumerator Example()
    {
        ifTouching = true;
        yield return new WaitForSeconds(1);
        gameManager.loadNextLevel();
    }
}