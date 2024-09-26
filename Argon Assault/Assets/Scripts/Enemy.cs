using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionVFX, enemyHitVFX;
    [SerializeField] int increaseScoreAmount = 10;
    [SerializeField] int hitAmount = 5;
    int takeHit = 0;

    ScoreBoard scoreBoard;
    GameObject parentGameobject;


    private void Start()
    {
        parentGameobject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
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
        vfx.transform.parent = parentGameobject.transform;
        
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameobject.transform;
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(increaseScoreAmount);
    }
}
