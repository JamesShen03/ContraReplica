using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{


    Rigidbody2D rb;


    public Rigidbody2D rb2;


    public float speed;


    public float jumpForce;
    public bool isGrounded;
    public bool isWatered;
    public LayerMask isGroundLayer;
    public LayerMask isWaterLayer;
    public Transform groundCheck;
    public Text scoreText;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;

    Animator anim;

    public Transform projectileSpawnPoint;

    public Projectile projectile;


    public bool isFacingLeft;

    int _lives = 3;

    public AudioClip jumpSnd;
    public AudioClip shootSnd;

    public AudioSource audioSource;




    void Start()
    {


        rb = GetComponent<Rigidbody2D>();

        if (!rb)
        {

            Debug.LogWarning("rb: No Rigidbody2D found on GameObject.");
        }

        if (!rb2)
        {

            Debug.LogWarning("rb2: No Rigidbody2D found on GameObject.");
        }


        if (speed <= 0.9f)
        {

            Debug.LogWarning("Speed variable not set. Setting to default value 5.");


            speed = 1.0f;
        }


        if (jumpForce <= 0.9f)
        {

            Debug.LogWarning("JumpForce variable not set. Setting to default value 5.");

            jumpForce = 4.0f;
        }


        if (!groundCheck)
        {
            Debug.LogError("no groundcheck set on character");
        }



        anim = GetComponent<Animator>();


        if (!anim)
        {

            Debug.LogWarning("No Animator found on GameObject.");
        }

        if (!projectileSpawnPoint)
        {
            Debug.LogError("No projectilespawnpoint found on character.");
        }



        if (!projectile)
        {
            Debug.LogError("No projectile found on character");
        }


        heart4.enabled = true;
        heart5.enabled = true;
        heart3.enabled = true;
        heart2.enabled = true;
        heart1.enabled = true;
    }

    void Update()
    {
        if (GameManager.instance.life < 5)
        {
            heart5.enabled = false;
        }
        if (GameManager.instance.life < 4)
        {
            heart4.enabled = false;
        }
        if (GameManager.instance.life >3)
        {
            heart4.enabled = true;
        }
        if (GameManager.instance.life >2)
        {
            heart3.enabled = true;
        }
        if (GameManager.instance.life > 1)
        {
            heart2.enabled = true;
        }
        if (GameManager.instance.life > 0)
        {
            heart1.enabled = true;
        }
        if (GameManager.instance.life > 4)
        {
            heart5.enabled = true;
        }

        if (GameManager.instance.life < 3)
        {
            heart3.enabled = false;
        }
        if (GameManager.instance.life < 2)
        {
            heart2.enabled = false;
        }
        if (GameManager.instance.life < 1)
        {
            heart1.enabled = false;
        }
        Debug.LogWarning(GameManager.instance.life);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, isGroundLayer);
        isWatered = Physics2D.OverlapCircle(groundCheck.position, 0.1f, isWaterLayer);

        float moveValue = Input.GetAxis("Horizontal");

        float crouchValue = Input.GetAxis("Vertical");

        anim.SetBool("Watered", isWatered);



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            PlaySound(jumpSnd);


        }

        if (Input.GetButtonDown("Jump") && isWatered)
        {


            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }




        if (Input.GetButtonDown("Fire1") & Time.timeScale > 0)
        {

            PlaySound(shootSnd);

            Projectile pTemp = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Projectile;
            if (isFacingLeft)
                pTemp.GetComponent<Projectile>().speed = 2;
            else if (!isFacingLeft)
                pTemp.GetComponent<Projectile>().speed = -2;


            Debug.Log("Pew Pew!");
        }


        rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);


        anim.SetFloat("Crouch", crouchValue);

        anim.SetFloat("Speed", Mathf.Abs(moveValue));


        anim.SetBool("Grounded", isGrounded);


        if (moveValue < 0 && isFacingLeft)
        {
            flip();
        }
        else if (moveValue > 0 && !isFacingLeft)
        { flip(); }

        if (GameManager.instance.life <= 0)
        {
            Destroy(gameObject);

        }

        scoreText.text = "Score: " + GameManager.instance.score;


    }

    void flip()
    {

        isFacingLeft = !isFacingLeft;


        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;

        transform.localScale = scaleFactor;

    }
    public int lives
    {
        get
        {
            // Returns private variable _lives value
            Debug.Log("Getting lives.");
            return _lives;
        }

        set
        {
            // Updates private variable _lives value
            Debug.Log("Setting lives.");
            _lives = value;
        }
    }
    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        // Assign AudioClip to AudioSource variable
        audioSource.clip = clip;

        // Assign Volume to AudioSource variable
        audioSource.volume = volume;

        // Play assigned AudioClip through AudioSource
        audioSource.Play();
    }
}
