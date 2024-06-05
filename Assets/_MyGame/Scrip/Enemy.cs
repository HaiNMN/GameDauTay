using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Transform playerTransform;

    HealthPlayer playerS;
    
    public int minDamage=10;
    public int maxDamage=0;

    public int healthEnemy = 10;

    LevelUp levelUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = collision.GetComponent<HealthPlayer>();
            InvokeRepeating( "DamagePlayer",0,0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        int dame = UnityEngine.Random.Range(minDamage, maxDamage);
        playerS.TakeDamage(dame);
    }

    // Start is called before the first frame update
    void Start()
    {
        levelUp = FindObjectOfType<LevelUp>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject == null )
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if(playerObject != null )
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            //
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null )
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction*moveSpeed*Time.deltaTime);
        }
    }

    public void TakeDamageEnemy(int damage)
    {
        healthEnemy -= damage;
        if (healthEnemy <= 0)
        {
            if(levelUp != null)
            {
                levelUp.UpEx(1);
            }
            Destroy(gameObject);
            GameManager.instance.AddScore(1);
            _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.KillEnemy);
        }
        
    }
}
