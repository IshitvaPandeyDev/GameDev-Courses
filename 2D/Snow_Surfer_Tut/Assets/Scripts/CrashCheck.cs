using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashCheck : MonoBehaviour
{
    [SerializeField] float LWaitTime = 1f;
    [SerializeField] ParticleSystem LPartcileSystem;
    PlayerController PlayerControl;
    private void Start()
    {
        PlayerControl = FindFirstObjectByType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int LayerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == LayerIndex)
        {
            LPartcileSystem.Play();
            Invoke("ReloadScene", LWaitTime);
            PlayerControl.DisableControl();
        }
        
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
