using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    // Reference to the player's collider
    public Collider playerCollider;

    // Reference to the enemy's collider
    public Collider enemyCollider1;
    public Collider enemyCollider2;

    GameManagerScript gameManagerScript;
    GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager");
        gameManagerScript = manager.GetComponent<GameManagerScript>();
    }

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
        AudioManager.instance.UseSoundEffect(2);
        gameManagerScript.gameOver();
        Time.timeScale = 0.0f;
    }
}