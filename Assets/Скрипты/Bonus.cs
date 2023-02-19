using UnityEngine;

public class Bonus : MonoBehaviour { //Скрипт бонуса, который увеличивает силу игрока

    PlayerShooting playerShooting;
    private void Start()
    {
        playerShooting = FindObjectOfType<PlayerShooting>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player") 
        {
            if (playerShooting.weaponPower != playerShooting.maxweaponPower)
            {
                playerShooting.weaponPower+=1;
            }
            else { }
            Destroy(gameObject);
        }
    }
}
