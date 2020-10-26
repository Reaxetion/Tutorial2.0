using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    public Text winText;

    public Text livesText;

    private int scoreValue = 0;

    private int lives = 3;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    public Animator anim;

    private bool facingRight = true;

    public bool onGround = true;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();

        // Setting up our initial HUD
        score.text = scoreValue.ToString();

        livesText.text = lives.ToString();

        SetCountText();
        SetLivesText();

        anim = GetComponent<Animator>();

        // Setting and playing the music
        musicSource.clip = musicClipOne;

        musicSource.Play();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

    }

    // Animating our little sprite
    void Update()

    {
        // Quit!
        if (Input.GetKey("escape"))
        {

            Application.Quit();

        }

        // Jumping! 
        if (onGround && Input.GetKeyDown(KeyCode.W))
        {
            onGround = false;
            anim.SetInteger("State", 2);
        }

        // Stop animating jump when we land
        if (Input.GetKeyUp(KeyCode.W) && onGround)
        {
            anim.SetInteger("State", 0);
        }

        // Go left
        if (Input.GetKeyDown(KeyCode.A) && onGround)
        {
            anim.SetInteger("State", 1);
        }

        // Go right
        if (Input.GetKeyDown(KeyCode.D) && onGround)

        {
            anim.SetInteger("State", 1);
        }
        // Reset on ground 
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && onGround)

        {
            anim.SetInteger("State", 0);
        }
        // Force us to fly!
        else if (onGround != true)
        {
            anim.SetInteger("State", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetCountText();

        }

        if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            livesText.text = lives.ToString();
            Destroy(collision.collider.gameObject);
            SetLivesText();

        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;

            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }

            if (collision.collider.tag == "Walls")
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rd2d.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
                }
            }
        }
    }

    void SetCountText()
    {
        score.text = "Count: " + scoreValue.ToString();

        if (scoreValue == 4)
        {
            transform.position = new Vector3(64f, -.33f, 0.0f);
            lives = 3;
            SetLivesText();
        }

        if (scoreValue == 8)
        {
            // Stop old music, play new music
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            // Display victory Text
            winText.text = "You win! Created by Austin Martin";
        }

    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            //Display defeat text
            winText.text = "You Lose! Presse Esc to Quit. Created by Austin Martin";
            Destroy(this);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}