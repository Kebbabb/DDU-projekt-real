using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Animator punchAnimator; // referanse til animator komponenten
    private float minInterval = 1f; // Minimum tid mellem slag
    private float maxInterval = 3f; // Maximum tid mellem slag
    public float initialSpeed = 1f;// Start hastighed
    public float speedIncreaseRate = 0.1f; // Hastigheds stigning
    public float maxSpeed = 4f; // Max hastighed

    //referanse til score text, der er 3 forskellige fordi vi har 3 forskellige UI elementer
    public TextMeshPro scoreText1;
    public TextMeshPro scoreText2;
    public TextMeshPro scoreText3;

    private int score = 0;
    private float currentSpeed;
    private float test = 0;

    public static EnemyController instance;

    private void Start()
    {
        
        int difficulty = PlayerPrefs.GetInt("Difficulty", 1);
        switch (difficulty)
        {
            case 0: // Easy
                Time.timeScale = 0.9f;
                break;
            case 1: // Medium
                Time.timeScale = 1.25f;
                minInterval = 3f;
                break;
            case 2: // Hard
                Time.timeScale = 1.4f;
                minInterval = 3f;
                break;
        }

   
    }


    void OnEnable()
    {
        instance = this; // Set the instance each time the scene loads
        

        UpdateScoreText();
        currentSpeed = initialSpeed; // Reset speed to initial value
        StartCoroutine(PunchCoroutine()); // Start the coroutine directly without persistence
    }

    private bool IsCoroutineRunning = false;

    public void RestartEnemyCoroutine()
    {
        StopAllCoroutines(); // Stops any running coroutines
        StartCoroutine(PunchCoroutine()); // Starts the punch coroutine again
    }

    public IEnumerator PunchCoroutine() // Changed from private to public
    {
        while (true)
        {
            currentSpeed = Mathf.Min(maxSpeed, currentSpeed + speedIncreaseRate);
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            punchAnimator.speed = currentSpeed;
            punchAnimator.SetTrigger(Random.value > 0.5f ? "LeftPunch" : "RightPunch");

            score++;
            UpdateScoreText();
        }
    }
    void UpdateScoreText()
    {
        scoreText1.text = score.ToString();
        scoreText2.text = score.ToString();
        scoreText3.text = score.ToString();
    }
}
