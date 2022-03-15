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
    public float FireDelay = 0.75f;
    Transform target;
    public AudioSource fireSound;
    public SpriteRenderer flash;
    bool IsAwake = false;
    public Transform player = null;
    
    void Start()
    {
        flash.enabled = false;
    }
    void FixedUpdate()
    {
        if (IsAwake == false)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            RaycastHit2D hit = Physics2D.Raycast(enemyCenter.position, new Vector2(player.position.x - enemyCenter.position.x, player.position.y - enemyCenter.position.y));
            
            if (hit.collider.tag == "Player")
            {
                IsAwake = true;
                StartCoroutine(Shooting());
            }
            Debug.Log($"Hit {hit.collider.name}");
        }
        if (IsAwake == true)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Vector3 dir = enemyCenter.position - target.position; 
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg; 
            transform.rotation = Quaternion.AngleAxis(angle -270, Vector3.forward);
        }
        if(Health == 0)
        {
            Destroy(Enemy);
        }
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
    void Shoot()
    {
        var bulletObject = Instantiate(BulletPrefab, GunTip.position, GunTip.rotation);
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
        rb.AddForce(GunTip.up * 25f, ForceMode2D.Impulse);
        fireSound.Play();
        StartCoroutine(FlashBehaivor());
    }
    IEnumerator Shooting()
    {
        while(Health > 0)
        {
            yield return new WaitForSeconds(FireDelay);
            Shoot();
            yield return new WaitForSeconds(FireDelay);   
        }
    }

    IEnumerator FlashBehaivor()
    {
        flash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        flash.enabled = false;
    }
}
