using UnityEngine;

public class RGloveMove : MonoBehaviour
{
    public float moveAmount = 1f; // The amount to move the object down
    public float moveSpeed = 5f;  // The speed of the movement

    private Vector3 originalPosition; // The original position of the object
    private Vector3 targetPosition;   // The target position when moving down
    private bool isMovingDown = false;

    void Start()
    {
        // Save the original position of the object
        originalPosition = transform.position;
        targetPosition = originalPosition - new Vector3(0, moveAmount, 0); // Moving down by moveAmount
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move towards the target position (downward)
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            isMovingDown = true;
        }
        else if (isMovingDown)
        {
            // Return to the original position smoothly when the left arrow key is released
            transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);

            // Check if the object is back to its original position
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                transform.position = originalPosition; // Snap to original position
                isMovingDown = false;
            }
        }
    }
}
