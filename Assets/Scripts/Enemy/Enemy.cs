using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
    Game
        Drop Item?
    */
    [SerializeField] int Health = 10;
    [SerializeField] Game game;
    [SerializeField] Weapon weapon;
    [SerializeField] Transform Fire1Spawn;

    float fire1Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
       var gameObject = GameObject.Find("Game");
       game = gameObject.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        fire1Timer += Time.deltaTime;
        if(fire1Timer > weapon.GetFireRate())
        {
            var projectile = Instantiate(weapon.GetCurrentProjectilePrefab(), Fire1Spawn.position, Quaternion.identity);
            projectile.GetComponent<ProjectileMovement>().IsEnemyProjectile = true;
            fire1Timer = 0.0f;
        }
    }

    public void TakeHit(int amount) 
    {
        Health = Health - amount;
        if (Health <= 0) {
            Die();
            return;
        }
        game.IncreaseScore(amount);
    }
    public void SetWeapon(Weapon NewWeapon)
    {
        weapon = NewWeapon;
    }
    private void Die()
    {
        game.IncreaseScore(Health);
        Destroy(this.gameObject);
    }
}
