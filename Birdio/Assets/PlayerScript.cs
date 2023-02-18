using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float speed = 2f;
    public float jumpForce = 8f; 
    private bool isGrounded;
    public int lives = 3;
    public Vector3 startPos;
    public Quaternion startRot;
    public bool inputEnabled= true;
    public Text livesLeft;
    public bool hasKey;
    public Image key;
    public GameObject Key;
    GameControllerScript gameController;
    Animator myAnim;
    BackgroundMusic bgAudio;
    public GameObject gameBgMusic;
    public bool hasLost;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        bgAudio = gameBgMusic.GetComponent<BackgroundMusic>();
        myAnim = GetComponent<Animator>();
    }
    void Update()
    {
        // here we are just making code for moving right and left x axis
        float horizontal = Input.GetAxis("Horizontal");
        
        if (Input.GetAxis("Horizontal") == 0)
        {
            myAnim.SetBool("isStanding", true);
            myAnim.SetBool("isWalking", false);
            
        }
        else
        {
            myAnim.SetBool("isStanding", false);
            myAnim.SetBool("isWalking", true);
            rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
        }
        // checking if space is pressed and if the character is in the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && inputEnabled)
        {
            // here we are applying the force to the jump well we reduced it by 25%
            Vector2 reducedImpulse = new Vector2(0, jumpForce);
            rigidBody2D.AddForce(reducedImpulse, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // iterating throught all the collisions that happen
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // so here it is checking if the collision point is upwards (for example me with the ground if i touch a side wall it wont trigger the if)
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public bool Revive(bool isReset)
    {
        LogicScript logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControllerScript>();
        if (isReset)
        {
            hasLost = false;
            bgAudio.isOn = true;
            logic.setToNull();
            lives = 3;
            hasKey = false;
            Key.gameObject.SetActive(true);
            key.gameObject.SetActive(false);
            livesLeft.text = lives.ToString() + " x Lives";
            transform.position = startPos;
            transform.rotation = startRot;
            return true;
        }
        else
        {
            if (lives > 0)
            {
                transform.position = startPos;
                transform.rotation = startRot;
                lives--;
                livesLeft.text = lives.ToString() + " x Lives";
                gameObject.SetActive(true);
                return true;
            }
            else
            {
                hasLost = true;
                bgAudio.isOn = false;
                transform.position = startPos;
                transform.rotation = startRot;
                gameObject.SetActive(true);
                gameController.gameOverRun("YOU LOSE !!");
                return false;
            }
        }
    }


}
