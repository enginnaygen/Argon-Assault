using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] PlayerController playerControlller;
    [SerializeField] float delay = 1f;
  
    private void OnTriggerEnter(Collider collision)
    {
        playerControlller.enabled = false;
        Invoke("ReStartScene", delay);
    }

    void ReStartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
}
