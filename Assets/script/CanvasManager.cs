using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Button start;



    // Use this for initialization
    void Start()
    {
        //start.onclick.AddListener(GameManager.instance.StartGame);   WORKSWHENUSING SINGLETON
        start.onClick.AddListener(GameObject.Find("GameManager").GetComponent<GameManager>().StartGame);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
