using UnityEngine;
using System.Collections;

public class enemy_walker : MonoBehaviour
{


    Rigidbody2D rb;


    public Rigidbody2D rb2;


    public float speed;

    public bool isFacingLeft;


    public AudioClip dieSnd;


    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        if (!rb)
        {

            Debug.LogWarning("rb: No Rigidbody2D found on GameObject.");
        }



        if (speed <= 0.9f)
        {

            Debug.LogWarning("Speed variable not set. Setting to default value 5.");


            speed = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft)
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "enemyCollider")
        {
            flip();
        }
    }

    void flip()
    {

        isFacingLeft = !isFacingLeft;


        Vector3 scaleFactor = transform.localScale;

        scaleFactor.x *= -1;

        transform.localScale = scaleFactor;

    }


    void OnCollisionEnter2D(Collision2D c)
    {

            if (c.gameObject.tag == "Player")
            {
            PlaySound(dieSnd);
                Destroy(gameObject);
            GameManager.instance.life -= 1;
            GameManager.instance.score += 1;


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

