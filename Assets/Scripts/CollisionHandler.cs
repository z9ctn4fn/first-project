using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject Bullet;
        
    void OnCollisionEnter2D(){
        Destroy(Bullet);
    }
    void Start(){
        StartCoroutine(DeleteBullet());
    }
    IEnumerator DeleteBullet(){
        yield return new WaitForSeconds(3);
        Destroy(Bullet);
    }
}
