using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem playerCollisionEffect;
    [SerializeField] float delay = 1f;
  
    private void OnTriggerEnter(Collider collision)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        playerCollisionEffect.Play();
        Invoke("ReloadScene", delay);

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
}
