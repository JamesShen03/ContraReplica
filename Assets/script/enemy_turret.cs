using UnityEngine;
using System.Collections;

public class enemy_turret : MonoBehaviour
{

    public Transform projectileSpawnPoint;

    public Transform target;

    float distance;

    public float range;

    float relativeDistance;

    public bool isFacingLeft;

    public Projectile projectile;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;

    public AudioClip dieSnd;
    public AudioClip shootSnd;

    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        if (projectileFireRate <= 0)
        {
            projectileFireRate = 0.2f;
        }
        if (range <= 0)
        {
            range = 2.00f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);

        relativeDistance = transform.position.x - target.position.x;


        if (Time.time > timeSinceLastFire + projectileFireRate & distance < range)
        {

            PlaySound(shootSnd);

            Projectile pTemp = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation) as Projectile;
            if (!isFacingLeft)
                pTemp.GetComponent<Projectile>().speed = 2;
            else if (isFacingLeft)
                pTemp.GetComponent<Projectile>().speed = -2;
            timeSinceLastFire = Time.time;
        }

        if (relativeDistance < 0 && isFacingLeft)
        {
            flip();
        }
        else if (relativeDistance > 0 && !isFacingLeft)
        { flip(); }


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