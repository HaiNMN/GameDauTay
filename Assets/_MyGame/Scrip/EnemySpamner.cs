using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpamner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float spamRate = 4f;// tốc độ tạo enemy
    public float spamRadius = 5f;
    private float spamTimer = 0f;
    private float toHard = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spamTimer += Time.deltaTime+toHard;
        if(spamTimer >= spamRate)
        {
            SpawnEnemy();
            toHard += 0.001f;
            spamTimer = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, spamRadius);
    }
    void SpawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position +Random.insideUnitCircle.normalized * spamRadius;

        Instantiate(enemyPrefabs, randomPosition, Quaternion.identity);
    }
}

