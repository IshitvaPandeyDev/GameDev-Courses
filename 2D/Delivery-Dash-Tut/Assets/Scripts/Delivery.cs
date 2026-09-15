using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using TMPro;
using System.Collections;
public class Delivery : MonoBehaviour
{
    bool haspackage;
    bool hasboost;
    [SerializeField] float delay = 1f;
    [SerializeField] TMP_Text PackageText;
    [SerializeField] TMP_Text BoostText;
    [SerializeField] TMP_Text DeliverText;

    private ParticleSystem partsys;
    void Start()
    {
        partsys = GetComponent<ParticleSystem>();
        PackageText.gameObject.SetActive(false);
        BoostText.gameObject.SetActive(false);
        DeliverText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Package") && !haspackage)
        {
            Debug.Log("Pick up");
            haspackage = true;
            UpdateParticlesAndPlay();
            PackageText.gameObject.SetActive(true);
            Destroy(collision.gameObject, delay);
        }
        if (collision.CompareTag("Boost") && !hasboost)
        {
            Debug.Log("Pick up");
            hasboost = true;
            UpdateParticlesAndPlay();
            BoostText.gameObject.SetActive(true);

        }
        if (collision.CompareTag("Customer") && haspackage)
        {
            Debug.Log("Delivered");
            haspackage = false;
            PackageText.gameObject.SetActive(false);
            StartCoroutine(ShowDeliveryTextRoutine());
            Destroy(collision.gameObject);
            UpdateParticlesAndPlay();

        }
    }
    private IEnumerator ShowDeliveryTextRoutine()
    {
        DeliverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f); 
        DeliverText.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasboost)
        {
            hasboost = false;
            UpdateParticlesAndPlay();
            BoostText.gameObject.SetActive(false);
        
    }
    }
    private void UpdateParticlesAndPlay()
    {
        var mainmodule = partsys.main;
        if (haspackage && hasboost)
        {
            mainmodule.startColor = Color.red;
            partsys.Play();
        }
        else if (haspackage)
        {
            mainmodule.startColor = new Color(0.5f, 0f, 0.5f);
            partsys.Play();
        }
        else if (hasboost)
        {
            mainmodule.startColor = new Color(1f, 0.5f, 0f);
            partsys.Play();
        }
        else
        {
            partsys.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        
    } 
    
}
