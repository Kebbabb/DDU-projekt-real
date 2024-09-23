using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public float moveAmount = 1f; // Amount to move the objects
    public float minInterval = 1f; // Minimum interval between movements
    public float maxInterval = 5f; // Maximum interval between movements
    public float initialSpeed = 2f; // Initial time to move and return to the original position
    public float speedIncreaseRate = 0.1f; // Rate at which the speed increases over time
    public float maxSpeed = 0.5f; // Maximum speed limit

    private Vector3 originalPosition1;
    private Vector3 originalPosition2;
    private float currentSpeed;

    void Start()
    {
        originalPosition1 = object1.transform.position;
        originalPosition2 = object2.transform.position;
        currentSpeed = initialSpeed;
        StartCoroutine(RandomMovementCoroutine());
    }

    IEnumerator RandomMovementCoroutine()
    {
        while (true)
        {
            // Wait for a random interval
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // Randomly select which object to move
            GameObject selectedObject = Random.value > 0.5f ? object1 : object2;
            Vector3 originalPosition = selectedObject == object1 ? originalPosition1 : originalPosition2;

            // Move the selected object
            yield return StartCoroutine(MoveObject(selectedObject, originalPosition));

            // Increase the speed gradually, but do not exceed maxSpeed
            currentSpeed = Mathf.Max(maxSpeed, currentSpeed - speedIncreaseRate);
        }
    }

    IEnumerator MoveObject(GameObject obj, Vector3 originalPosition)
    {
        // Move the object forward smoothly
        Vector3 targetPosition = obj.transform.position + obj.transform.forward * moveAmount;
        yield return StartCoroutine(MoveToPosition(obj, targetPosition));

        // Wait for the specified speed time
        yield return new WaitForSeconds(currentSpeed);

        // Return to the original position smoothly
        yield return StartCoroutine(MoveToPosition(obj, originalPosition));
    }

    IEnumerator MoveToPosition(GameObject obj, Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = obj.transform.position;

        while (elapsedTime < currentSpeed)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / currentSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
    
}