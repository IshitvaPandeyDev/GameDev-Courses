using UnityEngine;

public class CoinPickup : MonoBehaviour
{


    [SerializeField] AudioClip CoinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            FindFirstObjectByType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(CoinPickupSFX, transform.position);
            Destroy(gameObject);
        }
    }
}
