using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManagerScript : MonoBehaviour
{
    public EnemyController enemyController;
    public GameObject gameOverUI;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayWithDelay(1,0,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    private IEnumerator PlayWithDelay(int firstClipIndex, int secondClipIndex, float delay)
    {
        // Play first clip
        AudioManager.instance.audioSource.clip = AudioManager.instance.sources[firstClipIndex];
        AudioManager.instance.audioSource.Play();

        // Wait for the delay
        yield return new WaitForSeconds(delay);

        // Play second clip
        AudioManager.instance.audioSource.clip = AudioManager.instance.sources[secondClipIndex];
        AudioManager.instance.audioSource.Play();
    }

    
}
