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

    void Update()
    {
        float input = 0f;
        // Check for right arrow key input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetPosition = originalPosition + Vector3.right * moveAmount;
            input = 1f;

        }
        // Check for left arrow key input
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetPosition = originalPosition + Vector3.left * moveAmount;
            input = -1f;

        }
        
        else
        {
            // Return to the original position when no input is detected
            targetPosition = originalPosition;

        }

        float rotationAmount = input * rotationSpeed * Time.deltaTime;

        if (Mathf.Abs(currentRotation + rotationAmount) > maxRotation)
        {
            // Clamp the rotation amount to not exceed the maximum rotation
            rotationAmount = Mathf.Sign(rotationAmount) * (maxRotation - Mathf.Abs(currentRotation));
        }
        

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationAmount);

        currentRotation += rotationAmount;
        if (input == 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed / maxRotation);
            currentRotation = Mathf.Lerp(currentRotation, 0f, Time.deltaTime * rotationSpeed / maxRotation);
        }

    }
}