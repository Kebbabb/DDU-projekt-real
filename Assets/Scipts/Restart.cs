using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartButton()
    {
        StartCoroutine(RestartGameCoroutine());
    }

    private IEnumerator RestartGameCoroutine()
    {
        // Reload the scene
        SceneManager.LoadScene("Menu");

        // Wait briefly to ensure the scene is fully loaded
        yield return new WaitForSeconds(0.1f);

        // Reset time scale directly after scene load
        Time.timeScale = 1f;

        // Confirm the GameManagerScript instance and call RestartGame if necessary
        GameManagerScript gameManagerScript = FindObjectOfType<GameManagerScript>();
        if (gameManagerScript != null)
        {
            gameManagerScript.InitializeEnemyAfterSceneLoad();
            print("Restart button works");
        }
        else
        {
            Debug.LogError("GameManagerScript not found after scene reload.");
        }
    }
}
