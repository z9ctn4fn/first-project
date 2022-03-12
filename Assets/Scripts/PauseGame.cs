using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Text buttonText;
    public PlayerShooting Shooting;
    public bool isPaused = false;
    public void TogglePause(){
        if (isPaused == false){
            Time.timeScale = 0;
            buttonText.text = "Resume";
            isPaused = true;
            Shooting.enabled = false;
        }
        else if (isPaused == true){
            Time.timeScale = 1;
            buttonText.text = "Pause";
            isPaused = false;
            Shooting.enabled = true;
        }
    }
}
