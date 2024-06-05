using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] float speed=0.5f;
    public GameObject eye;
    private Rigidbody2D rb;
    [SerializeField] Camera maincamera;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maincamera = Camera.main;
    }
    private void FixedUpdate()
    {
        followMouse();
    }

    void followMouse()
    {
        Vector2 mousePosition = maincamera.ScreenToWorldPoint(Input.mousePosition); // lấy giá trị của chuột trong không gian thực
        Vector2 lookDirection = mousePosition - rb.position;  //Đây là vector hướng từ vị trí của nhân vật (rb.position) đến vị trí của chuột (mousePosition). Vector này chỉ ra hướng mà nhân vật cần nhìn.
        rb.velocity = lookDirection * speed; // hướng đi của nhân vật theo chuột

    }    
}
