using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float jumFore = 3f;
    private Rigidbody2D rb;
    private bool facingRight=true;
    private Animator anim;
    private int idRuning;
    private int idJump;

    public GameObject bullerPrefabs;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nexFireTime;
    public int diem;
    public int strongBullet=0;
    private float skillCoolDown = 5f;
    private float skillCoolDownTimer = 0f;
    private bool skillOnCooldown = false;
    public Image fillSkill;

    LevelUp levelUp;

    private Camera maincamera;

    [SerializeField] Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGround;
    private int maxJum = 2;
    private int jumCount = 0;

    public GameObject nor;
    public Transform jumPoint;

    public float dashBost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;
    public GameObject ghostEffect;
    public float ghostDelaySeconds;
    private Coroutine dashEffectCoreoutine;


    public static Move Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        idRuning = Animator.StringToHash("isRuning");
        idJump = Animator.StringToHash("isJump");
        rb = GetComponent<Rigidbody2D>();
        maincamera = Camera.main;
        levelUp = FindObjectOfType<LevelUp>();

    }
    

    // Update is called once per frame
    void Update()
    { 
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.07f, groundLayer);        
        if(isGround )
        {
            jumCount = 0;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput != 0 )
        {
            Movee(horizontalInput);

        }
        else
        {
            anim.SetBool(idRuning, false);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))&& jumCount<maxJum)
        {
            Jum();
            jumCount++;
        }
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumCount < maxJum)
        {
            NotJum();
        }
        if (Input.GetMouseButtonDown(0)&&Time.time>=nexFireTime)
        {
            Shoot();
            nexFireTime = Time.time+fireRate-diem/2;
            
        }
        

        if(skillOnCooldown)
        {
            skillCoolDownTimer -= Time.deltaTime;

            if(skillCoolDownTimer <=0)
            {
                skillOnCooldown = false;
                skillCoolDownTimer = 0;
            }
            UpdateSkill(skillCoolDownTimer / skillCoolDown);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SkillShoot();
            }
        }


        if(Input.GetMouseButtonDown(1) && _dashTime <=0 && isDashing == false)
        {
            moveSpeed += dashBost;
            jumFore += dashTime;
            _dashTime = dashTime;
            isDashing = true;
        }

        if(_dashTime <= 0 && isDashing == true)
        {
            jumFore -= dashTime;
            moveSpeed -= dashBost;
            isDashing = false;
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        RotatePlayer();
    }

    void Movee(float dir)
    {
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
        anim.SetBool(idRuning, true);
    }
    IEnumerator DestroyAfterDelay(GameObject obj, float delay) // xóa 1 obj nào đó , trong ... giây
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }

    void Jum()
    {

        rb.velocity = new Vector2(rb.velocity.x, jumFore);
        GameObject norInstance =  Instantiate(nor,jumPoint.position,jumPoint.rotation); // tạo obj norInstance
        StartCoroutine(DestroyAfterDelay(norInstance, 1f)); //StartCoroutine được sử dụng để bắt đầu thực thi một coroutine
        anim.SetBool(idJump, true);
        _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.jumAudio);
    }
    void NotJum()
    {
        anim.SetBool(idJump, false);
    }

    void Shoot()
    {
        // đạn bắng thẳng
        Instantiate(bullerPrefabs,firePoint.position, firePoint.rotation);

        if(strongBullet>=4)
        {
        // đạn bắn chéo lên
        Quaternion upAngle = Quaternion.Euler(0, 0, 15); // Quay 15 độ
        Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * upAngle);

        // đạn bắn chéo xuống
        Quaternion downAngle = Quaternion.Euler(0, 0, -15); // Quay -15 độ
        Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * downAngle);
        }
        if(strongBullet>=8)
        {
            // đạn bắn chéo lên
            Quaternion upAngle = Quaternion.Euler(0, 0, 30); // Quay 15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * upAngle);

            // đạn bắn chéo xuống
            Quaternion downAngle = Quaternion.Euler(0, 0, -30); // Quay -15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * downAngle);
        }
        if (strongBullet >= 12)
        {
            // đạn bắn chéo lên
            Quaternion upAngle = Quaternion.Euler(0, 0, 45); // Quay 15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * upAngle);

            // đạn bắn chéo xuống
            Quaternion downAngle = Quaternion.Euler(0, 0, -45); // Quay -15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * downAngle);
        }
        if (strongBullet >= 16)
        {
            // đạn bắn chéo lên
            Quaternion upAngle = Quaternion.Euler(0, 0, 60); // Quay 15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * upAngle);

            // đạn bắn chéo xuống
            Quaternion downAngle = Quaternion.Euler(0, 0, -60); // Quay -15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * downAngle);
        }
        if (strongBullet >= 20)
        {
            // đạn bắn chéo lên
            Quaternion upAngle = Quaternion.Euler(0, 0, 75); // Quay 15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * upAngle);

            // đạn bắn chéo xuống
            Quaternion downAngle = Quaternion.Euler(0, 0, -75); // Quay -15 độ
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * downAngle);
        }



        _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.fireAudio);
    }

    void SkillShoot()
    {
        Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation);
        //...........................................................
        for (int i = 15; i <= 180; i += 15) 
        {
            Quaternion upAngle = Quaternion.Euler(0, 0, i); 
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * upAngle);
        }

        //...........................................................
        for (int i = -15; i > -180; i -= 15)
        {
            Quaternion downAngle = Quaternion.Euler(0, 0, i); 
            Instantiate(bullerPrefabs, firePoint.position, firePoint.rotation * downAngle);
        }

        StartCoroutine(SkillCooldown());

        _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.Skill);
    }

    IEnumerator SkillCooldown()
    {
        skillOnCooldown = true;
        skillCoolDownTimer = skillCoolDown;

        yield return new WaitForSeconds(skillCoolDown);

        skillOnCooldown = false;
        skillCoolDownTimer = 0;
    }

    public void UpdateSkill(float cooldownPercentage)
    {
        fillSkill.fillAmount = cooldownPercentage;
    }

    void RotatePlayer()
    {
        if(maincamera != null)
        {
        Vector2 mousePosition = maincamera.ScreenToWorldPoint(Input.mousePosition); //Đây là cách để lấy vị trí của chuột trong không gian thế giới. ScreenToWorldPoint chuyển đổi vị trí của chuột từ không gian màn hình (pixel) sang không gian thế giới (toạ độ thực tế).
        Vector2 lookDirection = mousePosition - rb.position; //Đây là vector hướng từ vị trí của nhân vật (rb.position) đến vị trí của chuột (mousePosition). Vector này chỉ ra hướng mà nhân vật cần nhìn.
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; // Hàm Atan2 trả về góc giữa trục x dương và vector hướng lookDirection. Hàm này trả về kết quả trong radian, vì vậy ta nhân với Mathf.Rad2Deg để chuyển đổi sang độ.
        rb.rotation = angle; //Đây là cách để đặt góc quay của nhân vật (rb) sao cho nhân vật hướng về phía chuột. Góc quay này được tính từ trục x dương và quay theo chiều ngược kim đồng hồ (do cách góc được tính từ hàm Atan2)
        }
    }

    public void setBullet(int value)
    {
        strongBullet += value;
    }    

    public void setSpeedBullet(int value)
    {
        diem += value;
    }
}
