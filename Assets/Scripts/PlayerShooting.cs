using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce = 20f;
    public AudioSource fireSound;
    public SpriteRenderer flash;

    // Update is called once per frame
    void Start()
    {
        flash.enabled = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletObject; 
        bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);   
        fireSound.Play();
        StartCoroutine(FlashBehaivor());
    }
    IEnumerator FlashBehaivor()
    {
        flash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        flash.enabled = false;
    }
}
