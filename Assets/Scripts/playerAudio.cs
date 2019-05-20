using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudio : MonoBehaviour {


    public AudioClip JumpClip;
    public AudioSource JumpSource;
    public AudioClip EsplosionClip;
    public AudioSource EsplosionSource;

	// Use this for initialization
	void Start () {
        JumpSource.clip = JumpClip;
        EsplosionSource.clip = EsplosionClip;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            JumpSource.Play();
        }
    }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag.Equals("Enemy"))
            {
            EsplosionSource.Play();
            }
        }
    }
