using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject background;
    private RepeatBackground backgroundScript;  
    private bool isOnGround = true;
    public float jumpForce;
    public float gravityModifier;
    public bool gameOver = false;
    private Animator playerAnim;
    public int maxJumps = 1;
    private int jumps;
    public float objectSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        backgroundScript = background.GetComponent<RepeatBackground>();
        Physics.gravity *= gravityModifier;
        jumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& !gameOver)
        {
            if(jumps > 0)
            {
                playerAnim.SetTrigger("Jump_trig");
                rb.velocity = new Vector3(rb.velocity.x,0,rb.velocity.z);
                rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
                jumps -=1;
                isOnGround = false;
            }
            
        }
        if(Input.GetKey(KeyCode.LeftShift)&& !gameOver)
        {
            backgroundScript.speed = 10;
            objectSpeed = 20;
            playerAnim.SetFloat("Speed_f", 3);
        }else{
            backgroundScript.speed = 5;
            objectSpeed = 10;
            playerAnim.SetFloat("Speed_f", 1);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumps = maxJumps;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        
    }
}
