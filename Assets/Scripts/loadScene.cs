﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(Level);
        Time.timeScale = 1;
    }
}
