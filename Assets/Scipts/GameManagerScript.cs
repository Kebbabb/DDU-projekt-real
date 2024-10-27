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
        Time.timeScale = 1f;
        StartCoroutine(PlayWithDelay(1, 0, 1));
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0.08f;
    }

    // New method is now public to allow access from Restart.cs
    public IEnumerator InitializeEnemyAfterSceneLoad()
    {
        yield return new WaitForSeconds(0.1f); // Short delay to allow scene reload

        // Locate the new instance of EnemyController and reinitialize the coroutine
        EnemyController newEnemyController = FindObjectOfType<EnemyController>();
        if (newEnemyController != null)
        {
            newEnemyController.StartCoroutine(newEnemyController.PunchCoroutine()); // Restart coroutine explicitly
        }
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
