using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float WWaitTime = 1f;
    [SerializeField] ParticleSystem WPartcileSystem;
    ScoreManager ScoreManage;
    private void Start()
    {
        ScoreManage = FindFirstObjectByType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int LayerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == LayerIndex)
        {
            WPartcileSystem.Play();
            ScoreManage.AddScore(250);
            Invoke("ReloadScene", WWaitTime);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
