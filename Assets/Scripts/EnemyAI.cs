using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform enemyCenter;
    public Transform GunTip;
    public GameObject BulletPrefab;
    public GameObject Enemy;
    public int Health;
    Transform target;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 dir = enemyCenter.position - target.position; 
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.AngleAxis(angle -270, Vector3.forward);
        if(Health == 0)
        {
            Destroy(Enemy);
        }
        StartCoroutine(Shooting());
    }
    void OnCollisionEnter2D(Collision2D info)
    {
        if(info.collider.tag == "Danger")
        {
            Health = Health - 1;
            if(Health == 0)
            {
                Destroy(Enemy);
            }
        }
    }
    void Shoot(){
        var bulletObject = Instantiate(BulletPrefab, GunTip.position, GunTip.rotation);
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
        rb.AddForce(GunTip.up * 25f, ForceMode2D.Impulse);
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(1.5f);
        Shoot();
    }
}
