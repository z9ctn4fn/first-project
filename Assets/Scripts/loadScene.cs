using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScene : MonoBehaviour
{
    public void LoadLevel(string Level)
    {
        SceneManager.LoadScene(Level);
    }
}
