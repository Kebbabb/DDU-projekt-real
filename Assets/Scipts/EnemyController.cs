using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Animator punchAnimator; // referanse til animator komponenten
    public float minInterval = 1f; // Minimum tid mellem slag
    public float maxInterval = 5f; // Maximum tid mellem slag
    public float initialSpeed = 2f;// Start hastighed
    public float speedIncreaseRate = 0.1f; // Hastigheds stigning
    public float maxSpeed = 0.5f; // Max hastighed

    //referanse til score text, der er 3 forskellige fordi vi har 3 forskellige UI elementer
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

    IEnumerator PunchCoroutine()// Coroutine for at h�ndtere slag
    {
        while (true)// siger at den skal k�rer i en uendelig l�kke
        {
            //�ger hastigheden med speedIncreaseRate
            currentSpeed = Mathf.Min(maxSpeed, currentSpeed + speedIncreaseRate);

            // f�r coroutinen til at vente et tilf�ldigt antal sekunder mellem minInterval og maxInterval
            // f�r den k�rer igen
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // S�tter hastigheden p� animationen
            punchAnimator.speed = currentSpeed;

            // V�lger tilf�ldigt om det skal v�re et venstre eller h�jre slag
            float punchChoice = Random.value;
            if (punchChoice > 0.5f)
            {
                //laver et venstre slag
                punchAnimator.SetTrigger("LeftPunch");// aktiverer en parameter kaldet LeftPunch.
                                                      // dette vil starte animationen, der har parameteren LeftPunch
                                                      // i animator vinduet inde i unity.
            }
            else
            {
                //laver et h�jre slag
                punchAnimator.SetTrigger("RightPunch");// aktiverer en parameter kaldet RightPunch.
                                                       // dette vil starte animationen, der har parameteren RightPunch
                                                       // i animator vinduet inde i unity.
            }

            //�ger scoren med 1
            score++;
            UpdateScoreText();//opdaterer scoren i UI
        }
    }
    void UpdateScoreText()
    {
        scoreText1.text = score.ToString();
        scoreText2.text = score.ToString();
        scoreText3.text = score.ToString();
    }
}
