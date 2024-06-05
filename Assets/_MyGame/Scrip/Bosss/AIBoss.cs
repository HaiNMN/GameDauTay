using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class AIBoss : MonoBehaviour
{


    public int minDamage = 10;
    public int maxDamage = 0;

    public int healthBoss = 1000;

    //vật lý
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Transform target;
    private Vector3 targetPos;

    [SerializeField] private float stopDistance = 1;
    // điểm đi qua lại
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;


    // quay mặt
    [SerializeField] private SpriteRenderer flip;

    // animation
    [SerializeField] private Animator anim;

    public GameObject BulletPrefabs;
    public Transform firePoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = pointB.position;
    }

    private void Update()
    {
            Debug.Log(healthBoss);
            
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Shoot();
                anim.SetTrigger("IsAtack");
            }
            
            if(speed>=1)
            {
            anim.SetBool("IsRun", true);
            }
            else if(speed==0)
            {
            anim.SetBool("IsRun", false);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                targetPos = pointB.position;
                flip.flipX = true;
                anim.SetTrigger("IsIdle");
                
            }
            else if (transform.position == pointB.position)
            {
                targetPos = pointA.position;
                flip.flipX = false;
                anim.SetTrigger("IsIdle");
                
            }
            
            
            
    }

    public void TakeDamageBoss(int dame)
    {
        healthBoss -= dame;
        Debug.Log("boss");
        if(healthBoss < 0)
        {
            Destroy(gameObject);
        }
    }    

    void Shoot()
    {
        Instantiate(BulletPrefabs,firePoint.position,firePoint.rotation);
    }
}
