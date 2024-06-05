using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    private Rigidbody2D rb;
    public int diem;

    public int minDamage =4;
    public int maxDamage =10;

    AIBoss bossS;
    Enemy enemyS;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyS = collision.GetComponent<Enemy>();
            InvokeRepeating("DamageEnemy", 0, 0.1f);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Boss"))
        {
            bossS = collision.GetComponent <AIBoss>();
            InvokeRepeating("DamageBoss", 0, 0.1f);
            Destroy(gameObject);

        }  
    }

    void DamageEnemy()
    {
        int dame = UnityEngine.Random.Range(minDamage, maxDamage);
        enemyS.TakeDamageEnemy(dame);
        
    }

    void DamageBoss()
    {
        int dame = UnityEngine.Random.Range(minDamage, maxDamage);
        bossS.TakeDamageBoss(dame);
    }

}
