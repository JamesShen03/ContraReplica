using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    // Create a class variable to keep track of the SoundManager Instance
    // - Ensures only one copy of the Class
    // - defaulted to Private
    static SoundManager _instance = null;

    public AudioSource sfxSource;
    public AudioSource musicSource;


    public AudioClip level;


    // Use this for initialization
    void Start()
    {


        if (instance)
        {
            // SoundManager already exists
            // - Destroy second copy of SoundManager
            DestroyImmediate(gameObject);
        }
        else
        {
            // Assign SoundManager to variable _instance
            instance = this;

            // Tags this object as undestroyable
            // - Can exist from one Scene to the next
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "Title")
        {
            audio.Play();
            audio.clip = level;
            audio.Play();
        }
    }



    public void PlaySingleSound(AudioClip clip, float volume = 1.0f)
    {
        // Assign AudioClip to AudioSource variable
        sfxSource.clip = clip;

        // Assign Volume to AudioSource variable
        sfxSource.volume = volume;

        // Play assigned AudioClip through AudioSource
        sfxSource.Play();


    }

    // Provides access to private variable _instance
    // - Variable must be declared above
    // - Variable must be static
    public static SoundManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    
}
