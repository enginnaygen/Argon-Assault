using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionVFX, enemyHitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int increaseScoreAmount = 10;
    [SerializeField] int hitAmount = 5;
    int takeHit = 0;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        takeHit++;
        if(takeHit >= hitAmount)
        {
            ProcessHit();
            KillEnemy();
        }

        else
        {
            ProcessHit();
            HitEnemy();
        }

    }

    private void HitEnemy()
    {
        GameObject vfx = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(increaseScoreAmount);
    }
}
