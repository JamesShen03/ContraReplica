using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool paused = false;
    public Toggle mute;
    public Text muteText;
    public Text volumeText;
    public Slider volumeSlider;

    // Use this for initialization
    void Start()
    {
        PauseMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if (mute.isOn == true)
        {
            muteText.text = "Music is on!";
            AudioListener.pause = false;
        }
        else if (mute.isOn == false)
        {
            muteText.text = "Muted!";
            AudioListener.pause = true;

        }
        volumeText.text = "Volume is: " + Mathf.Round(volumeSlider.value * 10);
        AudioListener.volume = Mathf.Round(volumeSlider.value * 10);
    }

}