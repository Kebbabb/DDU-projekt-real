using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Animator punchAnimator; // Animator for the model's punches
    public float minInterval = 1f; // Minimum interval between punches
    public float maxInterval = 5f; // Maximum interval between punches
    public float initialSpeed = 2f; // Speed at which the punches happen
    public float speedIncreaseRate = 0.1f; // Rate at which punch speed increases over time
    public float maxSpeed = 0.5f; // Maximum speed limit for punches
    public TextMeshPro scoreText1;
    public TextMeshPro scoreText2;
    public TextMeshPro scoreText3;

    private int score = 0;
    private float currentSpeed;

    void Start()
    {
        UpdateScoreText();
        currentSpeed = initialSpeed;
        StartCoroutine(PunchCoroutine());
    }

    IEnumerator PunchCoroutine()
    {
        while (true)
        {
            // Wait for a random interval between punches
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // Randomly choose which punch to trigger
            float punchChoice = Random.value;
            if (punchChoice > 0.5f)
            {
                punchAnimator.SetTrigger("LeftPunch");
            }
            else
            {
                punchAnimator.SetTrigger("RightPunch");
            }

            // Wait for the punch animation to complete
            

            // Increase the speed of punching gradually but don't exceed maxSpeed
            currentSpeed = Mathf.Max(maxSpeed, currentSpeed - speedIncreaseRate);
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
