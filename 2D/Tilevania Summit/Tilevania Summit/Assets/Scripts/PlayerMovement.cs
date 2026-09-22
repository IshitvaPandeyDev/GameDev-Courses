using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2 (10f,20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;



    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    float gravityScaleAtStart;
    BoxCollider2D myFeetCollider;

    bool isAlive = true;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
        myFeetCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
    
        if(!isAlive){ return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }



    void OnMove(InputValue value)
    {
        if(!isAlive){ return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}
        if (value.isPressed )
        {
            myRigidBody.linearVelocity += new Vector2(0f,jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*moveSpeed, myRigidBody.linearVelocity.y);
        myRigidBody.linearVelocity = playerVelocity;
        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning",hasHorizontalSpeed);


    }
    
    void ClimbLadder()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidBody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing",false);
            return;
        }
        myRigidBody.gravityScale = 1f;
        Vector2 climbVelocity = new Vector2(myRigidBody.linearVelocity.x, moveInput.y*climbSpeed);
        myRigidBody.linearVelocity = climbVelocity;
        bool hasVerticalSpeed = Mathf.Abs(myRigidBody.linearVelocity.y)> Mathf.Epsilon;
        myAnimator.SetBool("isClimbing",hasVerticalSpeed);
    }

    void FlipSprite()
    {
    
        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.linearVelocity.x), 1f);
        }
    }

    void OnAttack(InputValue Value)
    {
        if(!isAlive){ return; }
        Instantiate(bullet, gun.position, transform.rotation);

    }


    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies","Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidBody.linearVelocity = deathKick;
            FindAnyObjectByType<GameSession>().ProcessPlayerDeath();

        }
    }

}
