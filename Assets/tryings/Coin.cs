using UnityEngine;

public class Coin : MonoBehaviour
{
    // This function will be called when the enemy collides with the coin
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the coin is the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
