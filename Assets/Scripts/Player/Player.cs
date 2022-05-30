using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Game game;
    [SerializeField] float BoostAmount = 2.0f;
    [SerializeField] SceneControl sceneControl;
    [SerializeField] GameObject DeathMessage;

    GameObject curDeathMessage;
    PlayerAttack playerAttack;

    bool spawnProtection = false;
    public float GetBoostAmount() { return BoostAmount; }

    void Start()
    {
       var gameObject = GameObject.Find("Game");
       game = gameObject.GetComponent<Game>();
       
       playerAttack = GetComponent<PlayerAttack>();

       game.updateHudElements();
    }

    void Update()
    {
        CheckPowerLevel();
    }

    public void TakeHit(int amount)
    {
        if(spawnProtection)
            return;

       game.DecreasePlayerHealth(amount);
        if (game.GetIsDead()) {
            Die();
            return;
        }
    }

    private void Die() 
    {
        //check game for respawn
        if (game.CheckRespawn())
        { 
            playerAttack.enabled = false;
            var sr = GetComponentInChildren<SpriteRenderer>();
            sr.enabled = false;
            //var collider = FindObjectOfType<BoxCollider2D>().enabled = false;
            game.Respawn();
            curDeathMessage = Instantiate(DeathMessage, Vector3.zero, Quaternion.identity);
            Time.timeScale = 0;                        
        } else {
            sceneControl.LoadScene(4);
            game.End();
            Destroy(gameObject);
        }
    }

    public void LiveAgain()
    {
        StartCoroutine(spawnProtectionDelay());
        playerAttack.enabled = true;
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.enabled = true;
    }
    IEnumerator spawnProtectionDelay()
    {
        print("spawnProtection on");
        spawnProtection = true;
        yield return new WaitForSeconds(3);
        //var collider = FindObjectOfType<BoxCollider2D>().enabled = true;
        spawnProtection = false;
        print("spawnProtection off");
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
