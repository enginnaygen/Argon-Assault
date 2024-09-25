using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyVFX;
    [SerializeField] Transform parent;
    [SerializeField] int increaseScoreAmount = 10;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(increaseScoreAmount);
    }
}
