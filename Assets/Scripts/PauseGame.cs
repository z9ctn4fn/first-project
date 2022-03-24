using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool paused = false;
    public Text buttonText;
    public void TogglePause()
    {
        if (paused == false)
        {
            Time.timeScale = 0;
            buttonText.text = "Resume";
            paused = true;
            Debug.Log("Paused");
            return; // so that unity dosen't unpause immediately
        }
        if (paused == true)
        {
            Time.timeScale = 1;
            buttonText.text = "Pause";
            paused = false;
            Debug.Log("Unpaused");
            return;
        }
    }
}
