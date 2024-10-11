using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{

    GameManagerScript gameManagerScript;
    GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager");
        gameManagerScript = manager.GetComponent<GameManagerScript>();
    }
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            AudioManager.instance.UseSoundEffect(2);
            gameManagerScript.gameOver();
            Time.timeScale = 0.0f;
        }
    }

}

