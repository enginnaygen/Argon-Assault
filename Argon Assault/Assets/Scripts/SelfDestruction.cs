using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    [SerializeField] float destructionDelay = 0.5f;

    private void Start()
    {
        DestructMyself();
    }
    void DestructMyself()
    {
        Destroy(this.gameObject, destructionDelay);
    }
}
