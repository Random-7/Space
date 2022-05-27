using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Game game;
    [SerializeField] int Health = 30;
    [SerializeField] float Speed = 5.0f;
    [SerializeField] float BoostAmount = 2.0f;


    public float GetSpeed() { return Speed; }
    public float GetBoostAmount() { return BoostAmount; }

    void Start()
    {
       var gameObject = GameObject.Find("Game");
       game = gameObject.GetComponent<Game>();

       //Get stats from game object???
    }
    public void TakeHit(int amount)
    {
        Health = Health - amount;
        if (Health <= 0) {
            Die();
            return;
        }
    }

    private void Die() 
    {
        //check game for respawn
            //respawn with improved stats
        //else
            //end game
        print("Dead");
    }
    
}
