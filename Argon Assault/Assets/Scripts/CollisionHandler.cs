using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Bridge")
        {
            Debug.Log("We crash on bridgeee!!");
        }
        else if(collision.tag == "Enemy")
        {
            Debug.Log("We crash on enemyy!");

        }
        else if (collision.tag == "World")
        {
            Debug.Log("We crash on environmentt!");

        }
    }

  
}
