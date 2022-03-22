using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalScript : MonoBehaviour
{
    public Canvas statusStuff;

    // Update is called once per frame
    void OnCollisionEnter2d(Collision2D info)
    {
        if(info.collider.tag == "Player")
        {
            statusStuff.enabled = true;
        }
    }
}
