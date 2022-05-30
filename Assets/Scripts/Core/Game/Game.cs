using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game game;
    [SerializeField] HudController hud;
    [SerializeField] private int playerMaxHealth = 30;
    [SerializeField] private int playerHealth;
    [SerializeField] private bool isDead = false;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private int score = 0;
    [SerializeField] private int waveCount = 0;

    [SerializeField] private int respawnEnergy = 0;
    [SerializeField] private int respawnEnergyTotal = 30;

    [SerializeField] private int powerLevel = 1;
    [SerializeField] private int powerLevelBar = 0;
    [SerializeField] private int powerLevelBarTotal = 15;

    [SerializeField] private int totalDeaths = 0;
    [SerializeField] Spawner spawner;
    [SerializeField] public List<GameObject> currentEnemies;

    public float GetPlayerSpeed() { return playerSpeed; }

    public int GetPlayerHealth() { return playerHealth; }
    public void IncreasePlayerHealth(int amount) 
    {
        playerHealth += amount;
        FindObjectOfType<HudController>().UpdateHealth(playerHealth);
    }
    public void DecreasePlayerHealth(int amount) 
    {
        playerHealth -= amount;
        if  (playerHealth <= 0)
        {
            isDead = true;
        }
        FindObjectOfType<HudController>().UpdateHealth(playerHealth);
        //hud.UpdateHealth(playerHealth);
    }
    public bool GetIsDead() { return isDead; }
    public int GetPlayerMaxHealth() { return playerMaxHealth; }
    public void IncreasePlayerMaxHealth(int amount)
    {
        playerMaxHealth += amount;
       FindObjectOfType<HudController>().UpdateMaxHealth(playerMaxHealth);
    }
    public int GetDeaths() { return totalDeaths; }
    public void IncreaseDeathCount(int amount)
    {
        totalDeaths += amount;
    }

    public int GetScore() { return score; }
    public void IncreaseScore(int amount) { score += amount; }

    public int GetWaveCount() { return waveCount; }
    public void IncreaseWaveCount(int amount) { waveCount += amount; }

    //Respawn mechanic - Score fills up bar for respawn
    // if player dies with full respawn bar, respawn player with upgraded stats
    public int GetRespawnEnergyLevel() { return respawnEnergy; }
    public int GetRespawnEnergyTotal() { return respawnEnergyTotal; }

    public void IncreaseRespawnEnergy(int amount) 
    {
        respawnEnergy += amount;
        if (respawnEnergy >= respawnEnergyTotal)
            respawnEnergy = respawnEnergyTotal;

         FindObjectOfType<HudController>().UpdateRespawnEnergy(respawnEnergy);
    }
    public bool CheckRespawn(){
        if (respawnEnergy == respawnEnergyTotal)
            return true;
        return false;
    }
    
    public void IncreaseRespawnEnergy()
    {
        respawnEnergyTotal = respawnEnergy + (respawnEnergyTotal / 2);
        FindObjectOfType<HudController>().UpdateRespawnEnergyTotal(respawnEnergyTotal);
    }

    //Power mechanic - power level scales up with score.
    // once hit a threshold upgrade the weapons.
    public int GetPowerLevel() { return powerLevel; }
    
    private void IncreasePowerLevel(int amount) 
    {
        powerLevelBarTotal = powerLevelBarTotal + ( powerLevelBarTotal / 4);
        FindObjectOfType<HudController>().UpdatePowerLevelBarTotal(powerLevelBarTotal);
        powerLevel += amount;
    }

    public int GetPowerLevelBar() { return powerLevelBar; }
    public int GetpowerLevelBarTotal() { return powerLevelBarTotal; }

    public void IncreasePowerLevelBar(int amount) 
    {
        powerLevelBar += amount;
        if (powerLevelBar >= powerLevelBarTotal)
        {
           IncreasePowerLevel(1);
           powerLevelBar = 0;
        }
        FindObjectOfType<HudController>().UpdatePowerLevelBar(powerLevelBar);
    }
    public void Respawn()
    {        
        DestroyAllEnemies();
        //increase the players max health
        if (powerLevel >= 5 && powerLevel <= 10)
        {
            IncreasePlayerHealth(10);
        } else if (powerLevel >= 10 && powerLevel <= 15)
        {
            IncreasePlayerHealth(20);
        }
        //Reset the player health
        playerHealth = playerMaxHealth;
        //Reset the respawn energy and increase the required amount
        respawnEnergy = 0;
        respawnEnergyTotal += 5;
        // reset power level bar
        powerLevelBar = 0;
        // Add to deaths
        IncreaseDeathCount(1);
        updateHudElements();
        FindObjectOfType<Spawner>().Respawn(waveCount);        
    }

    private void DestroyAllEnemies()
    {
        foreach (GameObject e in currentEnemies)
        {
            Destroy(e);
        }
    }

    public void RemoveEnemy(GameObject gameObject)
    {
        currentEnemies.Remove(gameObject);
    }

    public void End() 
    {
        Destroy(gameObject);
    }
    
    public void LiveAgain()
    {
        Time.timeScale = 1;
        Destroy(GameObject.FindGameObjectWithTag("DeathMessage"));
        FindObjectOfType<Player>().LiveAgain();
    }

    //Setup wave of waves, once done spawn another set
    //award score

    public void updateHudElements()
    {

        FindObjectOfType<HudController>().UpdateRespawnEnergyTotal(respawnEnergyTotal);
        FindObjectOfType<HudController>().UpdatePowerLevelBar(powerLevelBar);
        FindObjectOfType<HudController>().UpdatePowerLevelBarTotal(powerLevelBarTotal);
        FindObjectOfType<HudController>().UpdateMaxHealth(playerMaxHealth);
        FindObjectOfType<HudController>().UpdateHealth(playerHealth);
    }

    void Awake()
    {
        if (game == null)
            game = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        hud = FindObjectOfType<HudController>();
        playerHealth = playerMaxHealth;

        spawner = FindObjectOfType<Spawner>();
    }
}
