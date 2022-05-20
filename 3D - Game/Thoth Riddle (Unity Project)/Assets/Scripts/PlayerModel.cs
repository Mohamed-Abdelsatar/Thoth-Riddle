using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    public float speed = 5.0f;

    private const float speedLR = 4.0f;

    private float verticalVelocity = 0.0f;
    
    private float gravity = 12.0f;

    private float animationDuration = 3.0f;

    public float JumpForce = 10f;

    public Animator animator;

    private bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {      
        float MoveX = Input.GetAxisRaw("Horizontal");

        if (isDead)
            return;

        if (Time.timeSinceLevelLoad < animationDuration)
        {
            animator.SetBool("isGrounded", true);
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (controller.isGrounded)
            {
                Jump();
            }
        }

        if (!controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            MoveX = 0;           
        } 

        moveVector = Vector3.zero;

        // X Left-Right
        moveVector.x = MoveX * speedLR;

        if (Input.GetMouseButton(0))
        {
            //Right Side
            if (Input.mousePosition.x > Screen.width/2 && Input.mousePosition.y < Screen.height / 3 && controller.isGrounded)
                moveVector.x = speedLR;
            else if (Input.mousePosition.x < Screen.width/2 && Input.mousePosition.y < Screen.height / 3 && controller.isGrounded)
                moveVector.x = -speedLR;
            else if(Input.mousePosition.y > Screen.height/3 && controller.isGrounded)
                Jump();
        }

        // Y Up-Down
        moveVector.y = verticalVelocity;
        // Z Forward-Backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        animator.SetBool("isGrounded", controller.isGrounded);
    }

    private void Jump()
    {
        GameObject JumpSfX = GameObject.FindGameObjectWithTag("JumpSound");

        JumpSfX.GetComponent<AudioSource>().Play();

        verticalVelocity = JumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
            Death ();
    }

    private void Death()
    {
        GameObject DeathSfX = GameObject.FindGameObjectWithTag("DeathSound");

        DeathSfX.GetComponent<AudioSource>().Play();

        isDead = true;
        GetComponent<Score>().OnDeath();
        this.gameObject.SetActive(false);
        GameObject CoinCounter = GameObject.FindGameObjectWithTag("CoinCounter");
        CoinCounter.SetActive(false);        
    }

    public void SetSpeed(float modifier)
    {
        speed = 4.0f + modifier;
    }

}
