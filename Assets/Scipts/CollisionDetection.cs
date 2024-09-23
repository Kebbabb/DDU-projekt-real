using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    // Reference to the player's collider
    public Collider playerCollider;

    // Reference to the enemy's collider
    public Collider enemyCollider;

    void Update()
    {
        CheckForCollision();
    }

    void CheckForCollision()
    {
        // Check if the player's collider is intersecting with the enemy's collider
        if (playerCollider.bounds.Intersects(enemyCollider.bounds))
        {
            // Handle collision
            OnEnemyCollision();
        }
    }

    void OnEnemyCollision()
    {
       Time.timeScale = 0;
    }
}