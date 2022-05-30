using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public AudioClip dieSnd;


    public AudioSource audioSource;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {

            PlaySound(dieSnd);
            Destroy(gameObject);
            GameManager.instance.life += 1;
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
