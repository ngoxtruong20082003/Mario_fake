using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuCharacterRunner : MonoBehaviour
{

    public float speed = 3f;
    public float moveSpeed = 5f;
    //public float jumpPow1 = 15f;
    private Rigidbody2D rb;
   // float HorizontalMovement;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
         Move();
        UpdateAnimation();
    }

    private void Move()
    {
         float moveInput = Input.GetAxis("Horizontal");
         rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
         if(moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if(moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    


    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        animator.SetBool("isRunning", isRunning);

    }
}
