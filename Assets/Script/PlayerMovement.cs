using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    float HorizontalMovement;

    [Header("Jump")]
    public float jumpPow = 15f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize =new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    private GameManager gameManager;
    private AudioManager audioManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.IsGameOver()|| gameManager.IsGameWin()) return;
       rb.velocity = new Vector2(HorizontalMovement * moveSpeed, rb.velocity.y);
       if(HorizontalMovement > 0) transform.localScale = new Vector3(1, 1, 1);
       else if(HorizontalMovement < 0) transform.localScale = new Vector3(-1, 1, 1);
       UpdateAnimation();
    }

    public void Move(InputAction.CallbackContext context)
    {       
        HorizontalMovement = context.ReadValue<Vector2>().x;    
    }

    public void Jump(InputAction.CallbackContext context)
    {   
        if(isGrounded())
        {
            if(context.performed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPow);
            audioManager.PlayJumpSound();
        }
        }
        
    }


    private bool isGrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
    }

    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded();
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }

     public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.Instance.TogglePause();
        }
    }
}
