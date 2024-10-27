using UnityEngine;

public class RGloveMove : MonoBehaviour
{
    public float moveAmount = 1f; // hvormeget handsken skal bevæges ned
    public float moveSpeed = 5f;  // hvor hurtigt handsken skal bevæges ned

    private Vector3 originalPosition; // Handskens originale position
    private Vector3 targetPosition;  // den poition som handsken skal rykkes til
    private bool isMovingDown = false;

    void Start()
    {
        // gemmer den originale position af handsken
        originalPosition = transform.position;
        targetPosition = originalPosition - new Vector3(0, moveAmount, 0); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // bevæger handsken ned mod "targetposition" hvis højre piltast trykkes ned
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            isMovingDown = true;
            
        }
        else if (isMovingDown)
        {
            // bevæger handsken tilbage til original position hvis højre piltast ikke længere er trykket ned
            transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);

            // tjekker om handsken er tæt nok på original position til at "snappe" tilbage
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                transform.position = originalPosition; // sætter handsken til original position
                isMovingDown = false;
            }
        }
    }
}
