using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    public float bulletForce = 20f;
    public AudioSource fireSound;
    public SpriteRenderer flash;
    public GameObject pistol;
    public GameObject shotgun;
    public Transform shotgunfirepoint1;
    public Transform shotgunfirepoint2;
    public Transform shotgunfirepoint3;
    private string equippedWeapon = "pistol";
    bool canShoot = true;

    // Update is called once per frame
    void Start()
    {
        flash.enabled = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StopCoroutine(Shooting());
            StartCoroutine(Shooting());
        }
        if(Input.GetButtonDown("1"))
        {
            shotgun.SetActive(false);
            pistol.SetActive(true);
            equippedWeapon = "pistol";
        }
        if(Input.GetButtonDown("2"))
        {
            shotgun.SetActive(true);
            pistol.SetActive(false);
            equippedWeapon = "shotgun";
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
    IEnumerator Shooting()
    {
        if (canShoot == true)
        {
            canShoot = false;
            Shoot();
            yield return new WaitForSeconds(0.25f);
            canShoot = true;
        }

    }

}
