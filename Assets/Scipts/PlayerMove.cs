using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the camera movement
    public float moveAmount = 1f; // Amount to move the camera

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    void Start()
    {
        // Initialize the original and target positions to the current position
        originalPosition = transform.position;
        targetPosition = transform.position;
    }

    void Update()
    {
        // Check for right arrow key input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetPosition = originalPosition + Vector3.right * moveAmount;
        }
        // Check for left arrow key input
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetPosition = originalPosition + Vector3.left * moveAmount;
        }
        else
        {
            // Return to the original position when no input is detected
            targetPosition = originalPosition;
        }

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}