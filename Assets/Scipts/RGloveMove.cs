using UnityEngine;

public class RGloveMove : MonoBehaviour
{
    public float moveAmount = 1f; // hvormeget handsken skal bev�ges ned
    public float moveSpeed = 5f;  // hvor hurtigt handsken skal bev�ges ned

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
            // bev�ger handsken ned mod "targetposition" hvis h�jre piltast trykkes ned
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            isMovingDown = true;
            
        }
        else if (isMovingDown)
        {
            // bev�ger handsken tilbage til original position hvis h�jre piltast ikke l�ngere er trykket ned
            transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);

            // tjekker om handsken er t�t nok p� original position til at "snappe" tilbage
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                transform.position = originalPosition; // s�tter handsken til original position
                isMovingDown = false;
            }
        }
    }
}
