using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float jumpForce = 300.0f;
    Rigidbody2D rigid2D;
    Animator animator;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            var touch = Input.GetTouch(0);  
            float halfWidth = Screen.width / 2;
            Vector2 touchPosition = touch.position;
            
            if (touch.phase == TouchPhase.Began)
            {
                int key = halfWidth < touchPosition.x ? 1 : -1;
                
                this.rigid2D.velocity = new Vector2(0f, 0f);
                this.rigid2D.AddForce(transform.up * this.jumpForce);
                this.rigid2D.AddForce(transform.right * (touchPosition.x - halfWidth));

                this.animator.SetBool("jump", true);

                if (key != 0)
                {
                    transform.localScale = new Vector3(key, 1, 1);
                }
            }
        }
        // 壁の当たり判定
        Vector2 position = transform.position;
        position.x = Math.Max(-2.2f, Math.Min(position.x, 2.2f));
        transform.position = position;

        this.animator.speed = Mathf.Abs(this.rigid2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("ゴール");  
        SceneManager.LoadScene("GameOverScene");
    }
}
