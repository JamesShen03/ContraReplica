using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static GameManager _instance = null;
    public int life = 5;
    public int score = 100;
    void Start()
    {
        if (instance)
        {
   
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;


            DontDestroyOnLoad(this);

        }


    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (SceneManager.GetActiveScene().name == "GameOver")
            {
                SceneManager.LoadScene(0);
            }
            if (SceneManager.GetActiveScene().name == "level")
            {
                SceneManager.LoadScene(1);
            }

        }





    }


    public void StartGame()
    {
        SceneManager.LoadScene("level");
    }


    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }


}
