using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{


    public float projectileLifeTime;


    public float speed;



    
    void Start()
    {




        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        if (projectileLifeTime == 0)
        {
            projectileLifeTime = 1.0f;
            Destroy(gameObject, projectileLifeTime);
        }



    }
    
    void Update()
    {
       





    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (gameObject.tag == "Bullet")
        {
            if (c.gameObject.tag != "Player" && c.gameObject.tag != "Bullet")
            {
                Destroy(gameObject);
                if (c.gameObject.tag == "enemies")
                {
                    Destroy(c.gameObject);
                    GameManager.instance.score += 1;

                }


            }

        }
        else if (gameObject.tag == "enemyBullet")
        {
            if (c.gameObject.tag != "enemies" && c.gameObject.tag != "enemyBullet")
            {
                Destroy(gameObject);
                if (c.gameObject.tag == "Player")
                {
                    GameManager.instance.life -= 1;
                }
            }
        }


    }



}
