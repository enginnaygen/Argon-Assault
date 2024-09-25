using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"Hit enemy by {other.name}");
        //Destroy(this.gameObject);
    }
}
