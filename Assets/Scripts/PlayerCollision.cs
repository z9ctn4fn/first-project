using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement Movement;
    public PlayerShooting Shooting;
    public Text HealthText;
    int Health = 3;

    void OnCollisionEnter2D(Collision2D info)
    {
        if(info.collider.tag == "Danger")
        {
            Debug.Log("Hit");
            Health = Health - 1;
            if(Health == 0){
                Movement.enabled = false;
                Shooting.enabled = false;
                HealthText.text = "You are dead";
            }
            
        }
    }
    void Update()
    {
        HealthText.text = $"Health: {Health}";
    }
}
