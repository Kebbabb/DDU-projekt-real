using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    
    public void SetEasyDifficulty()
    {
        Time.timeScale = 0.75f; // Slow down game slightly for Easy
        PlayerPrefs.SetInt("Difficulty", 0);
        LoadMainScene();
    }

    public void SetMediumDifficulty()
    {
        Time.timeScale = 0.85f; // Normal game speed for Medium
        PlayerPrefs.SetInt("Difficulty", 1);
        LoadMainScene();
    }

    public void SetHardDifficulty()
    {
        Time.timeScale = 1f; // Speed up game for Hard
        PlayerPrefs.SetInt("Difficulty", 2);
        LoadMainScene();
    }

    private void LoadMainScene()
    {
        // Replace "MainScene" with your actual main scene name
        SceneManager.LoadScene("MainScene");
    }
}
