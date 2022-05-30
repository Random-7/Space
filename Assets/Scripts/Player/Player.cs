using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Game game;
    [SerializeField] int Health = 30;
    [SerializeField] int MaxHealth = 30;
    [SerializeField] float Speed = 5.0f;
    [SerializeField] float BoostAmount = 2.0f;

    PlayerAttack playerAttack;
    HudController hud;
    public float GetSpeed() { return Speed; }
    public float GetBoostAmount() { return BoostAmount; }

    void Start()
    {
       var gameObject = GameObject.Find("Game");
       game = gameObject.GetComponent<Game>();
       
       playerAttack = GetComponent<PlayerAttack>();

       
       hud = GameObject.FindObjectOfType<HudController>();
       hud.UpdateMaxHealth(MaxHealth);
       hud.UpdateHealth(Health);
    }

    void Update()
    {
        CheckPowerLevel();
    }


    public void TakeHit(int amount)
    {
        Health = Health - amount;
        hud.UpdateHealth(Health);
        if (Health <= 0) {
            Die();
            hud.UpdateHealth(0);
            return;
        }
    }

    private void Die() 
    {
        //check game for respawn
        if (game.CheckRespawn())
        {

            //respawn with improved stats
            UpdateStats();
        } else {
            // end game
        }
    }
    
    private void UpdateStats()
    {

    }

    private void CheckPowerLevel()
    {

        if ( game.GetPowerLevel() >= 5 )
        {
            playerAttack.UgradeWeapons(1);
        } else if ( game.GetPowerLevel() >= 10)
        {
            playerAttack.UgradeWeapons(2);
        }
    }
}
