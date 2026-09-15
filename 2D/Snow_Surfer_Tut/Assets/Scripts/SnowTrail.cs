using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem SnowEffect;
    
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int LayerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == LayerIndex)
        {
            SnowEffect.Play();
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        int LayerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == LayerIndex)
        {
            SnowEffect.Stop();
        }
    }
}
