using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the camera movement
    public float moveAmount = 1f; // Amount to move the camera
    public float rotationSpeed = 90f;
    public float maxRotation = 45f;

    private float currentRotation = 0f;

    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private Vector3 targetPosition;


    void Start()
    {
        // Initialize the original and target positions to the current position
        originalPosition = transform.position;
        targetPosition = transform.position;
        originalRotation = transform.rotation;
          

    }

    //i void Update() metoden tjekker vi for input fra piletasterne
    //og initialisere den variabel vi skal bruge til at flytte objektet til højre eller venstre
    void Update()// Update er kaldet 1 gang "per frame"
    {
        float input = 0f;
        // checker for input fra piletast højre 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetPosition = originalPosition + Vector3.right * moveAmount;// flytter objektet til højre
            input = 1f;// sætter input til 1 som skal bruges sænere til at rotere objektet

        }
        // checker for input fra piletast venstre
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetPosition = originalPosition + Vector3.left * moveAmount;// flytter objektet til venstre
            input = -1f;//sætter input til -1 som skal bruges sænere til at rotere objektet

        }

        else// hvis der ikke er input fra piletasterne skal objektet gå tilbage til original position
        {
            
            targetPosition = originalPosition;

        }

        float rotationAmount = input * rotationSpeed * Time.deltaTime;
        // beregner matematisk hvor meget objektet skal rotere

        if (Mathf.Abs(currentRotation + rotationAmount) > maxRotation)// tjekker om objektet har roteret for meget
        {
            // Hvis objektet har roteret for meget, så sætter den rotationAmount til at objektet skal rotere tilbage til maxRotation
            rotationAmount = Mathf.Sign(rotationAmount) * (maxRotation - Mathf.Abs(currentRotation));
        }


        // Flytter objektet til targetPosition som er den position objektet skal flytte til beregnet tidligere
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Roterer objektet
        transform.Rotate(Vector3.up, rotationAmount);
        // Opdaterer currentRotation som bruges til at tjekke om objektet har roteret for meget
        currentRotation += rotationAmount;

        // hvis, der ikke længere er input fra piletasterne, så skal objektet rotere tilbage til originalRotation
        if (input == 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed / maxRotation);
            currentRotation = Mathf.Lerp(currentRotation, 0f, Time.deltaTime * rotationSpeed / maxRotation);
        }

    }
}