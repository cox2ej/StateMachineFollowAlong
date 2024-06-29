using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string message = "You have interacted with the object!";
    public float interactionDistance = 2f;
    public Color interactedColor = Color.green; // Color to change to upon interaction

    private Transform player;
    private Renderer objectRenderer;
    private EnemyController[] enemies;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure your player has the tag 'Player'.");
        }

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("No Renderer found on the interactable object.");
        }

        enemies = FindObjectsOfType<EnemyController>();
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing.");
            return;
        }

        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        Debug.Log(message);
        ChangeColor(interactedColor);
        StopEnemies();
        // Additional interaction logic can be added here
    }

    private void ChangeColor(Color newColor)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = newColor;
        }
    }

    private void StopEnemies()
    {
        foreach (EnemyController enemy in enemies)
        {
            enemy.StopMovement();
        }
    }
}
