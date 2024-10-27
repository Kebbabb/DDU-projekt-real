using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    // reference til spillerens collider
    public Collider playerCollider;

    // reference til enemy colliders. der er 2 fordi hver hånd har sin egen collider
    public Collider enemyCollider1;
    public Collider enemyCollider2;

    // reference til GameManagerScript
    GameManagerScript gameManagerScript;
    GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager");// finder GameManager objektet
        gameManagerScript = manager.GetComponent<GameManagerScript>();// henter GameManagerScript komponenten fra GameManager objektet
    }

    void Update()
    {
        CheckForCollision();// kalder CheckForCollision metoden
    }

    void CheckForCollision()//metode til at tjekke for kollision mellem spiller og enemy
    {
        if (playerCollider == null || enemyCollider1 == null || enemyCollider2 == null)
        {
            return; // Exit the method if any collider is missing
        }
        // Tjekker om spillerens collider kolliderer med enemy1(venstrehånd) eller enemy2(højrehånd) colliders
        if (playerCollider.bounds.Intersects(enemyCollider1.bounds))
        {
            // kører funktionen OnEnemyCollision hvis der er kollision
            OnEnemyCollision();
        }
        else if (playerCollider.bounds.Intersects(enemyCollider2.bounds))
        {
            // kører funktionen OnEnemyCollision hvis der er kollision
            OnEnemyCollision();
        }
    }

    void OnEnemyCollision()//beskriver hvad der skal ske når der er kollision mellem spiller og enemy
    {
        AudioManager.instance.UseSoundEffect(2);// afspiller lyd effekt 2
        gameManagerScript.gameOver();// kalder gameOver metoden fra GameManagerScript
        //ganeOver metoden fra GameManagerScript aktiverer gameOverUI som er et gameobject i unity, der viser,
        //at spillet er slut.
       
    }
}