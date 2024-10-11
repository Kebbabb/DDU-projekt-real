using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    // Reference to the player's collider
    public Collider playerCollider;

    // Reference to the enemy's collider
    public Collider enemyCollider1;
    public Collider enemyCollider2;

    void Update()
    {
        CheckForCollision();
    }

    void CheckForCollision()
    {
        // Check if the player's collider is intersecting with the enemy's collider
        if (playerCollider.bounds.Intersects(enemyCollider1.bounds))
        {
            // Handle collision
            OnEnemyCollision();
        }
        else if (playerCollider.bounds.Intersects(enemyCollider2.bounds))
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