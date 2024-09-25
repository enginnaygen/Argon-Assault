using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyVFX;
    [SerializeField] Transform parent;

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"Hit enemy by {other.name}");
        GameObject vfx = Instantiate(enemyVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
