using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    [SerializeField] public float speed = 40f;
    [SerializeField] public float jumpForce = 0;
    private float moveInput = 0;

    private Rigidbody2D rb;

    private bool facingRight = true; 

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isTouching;
    public Transform endCheck;
    public float checkEndRadius;
    public LayerMask whatIsEnd;

    private int extraJumps;
    public int extraJumpsValue;
    public Animator animator;

    public GameObject octopode;

    public GameManager gameManager;


    void Start(){

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isTouching = Physics2D.OverlapCircle(endCheck.position, checkEndRadius, whatIsEnd);

        moveInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            octopode.SetActive(false);
            animator.SetBool("IsDed", true);
            PlayerController cc = GetComponent<PlayerController>();
            cc.enabled = false;
        }
    }


    void Update(){

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if(isGrounded  == true){
            extraJumps = extraJumpsValue;
            animator.SetBool("IsJumping", false);
        }

        if(isGrounded == false){
            animator.SetBool("IsJumping", true);
        }

        if (isTouching == true)
        {
            animator.SetBool("IsTouchingPillar", true);
            PlayerController cc = GetComponent<PlayerController>();
            cc.enabled = false;
        }
    

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 || Input.GetKeyDown(KeyCode.W) && extraJumps > 0 || Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            animator.SetBool("IsJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void StartNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void deathAnimation()
    {
        gameManager.gameOver();
    }
}
