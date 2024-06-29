using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;

    void Start()
    {
        // Destroy the projectile after a set amount of time to avoid memory leaks
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy and the projectile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Destroy the projectile if it hits anything else
            Destroy(gameObject);
        }
    }
}
