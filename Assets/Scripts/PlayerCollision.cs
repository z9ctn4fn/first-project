using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement Movement;
    public PlayerShooting Shooting;
    public Text HealthText;
    int Health = 3;
    public Canvas endStuff;
    public Text endText;
    public Image nextLevel;
    public Button nextLevelButton;

    void OnCollisionEnter2D(Collision2D info)
    {
        if(info.collider.tag == "Danger")
        {
            Debug.Log("Hit");
            Health = Health - 1;
            if(Health <= 0){
                Movement.enabled = false;
                Shooting.enabled = false;
                HealthText.text = "You are dead";
                endStuff.enabled = true;
                endText.text = "LEVEL = FAILED";
                nextLevel.enabled = false;
                nextLevelButton.enabled = false;
                Time.timeScale = 0;
            }
            
        }
        if(info.collider.tag == "Goal")
        {
            Debug.Log("Win");
            Time.timeScale = 0;
            endStuff.enabled = true;
        }
    }
    void Update()
    {
        HealthText.text = $"Health: {Health}";
    }
}
