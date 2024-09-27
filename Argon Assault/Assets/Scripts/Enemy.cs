using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionFX, enemyHitVFX;
    [SerializeField] int increaseScoreAmountHit = 10;
    [SerializeField] int increaseScoreAmountKill = 50;
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
            ProcessHit(increaseScoreAmountHit);
            KillEnemy();
        }

        else
        {
            ProcessHit(increaseScoreAmountKill);
            HitEnemy();
        }

    }

    private void HitEnemy()
    {
        GameObject fx = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameobject.transform;
        
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosionFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameobject.transform;
        Destroy(this.gameObject);
    }

    private void ProcessHit(int amount)
    {
        scoreBoard.IncreaseScore(amount);
    }
}
