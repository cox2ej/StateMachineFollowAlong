using UnityEngine;
using UnityEngine.SceneManagement; // For reloading the scene or handling game over

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform player;
    private bool stopMoving = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!stopMoving)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void StopMovement()
    {
        stopMoving = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && (!stopMoving))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! The enemy touched the player.");
        // Reload the scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
