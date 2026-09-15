using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUpSL PowerUp;
    PlayerController Player;
    SpriteRenderer Sprite;
    float TimeLeft;
    private void Start()
    {
        Player = FindFirstObjectByType<PlayerController>();
        Sprite = GetComponent<SpriteRenderer>();
        TimeLeft = PowerUp.GetTime();
    }
    private void Update()
    {
        CountdownTimer();
    }
    void CountdownTimer()
    {
        if (Sprite.enabled == false)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;

                if (TimeLeft <= 0)
                {
                    Player.DeactivatePowerUP(PowerUp);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        int LayerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == LayerIndex && Sprite.enabled)
        {
           Sprite.enabled = false;
           Player.ActivatePowerUp(PowerUp);
        }
    }
}
