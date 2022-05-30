using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] HudController hud;
    [SerializeField] private int score = 0;
    [SerializeField] private int waveCount = 0;

    [SerializeField] private int respawnEnergy = 0;
    [SerializeField] private int respawnEnergyTotal = 30;

    [SerializeField] private int powerLevel = 1;
    [SerializeField] private int powerLevelBar = 0;
    [SerializeField] private int powerLevelBarTotal = 15;

    [SerializeField] private int totalDeaths = 0;

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

        hud.UpdateRespawnEnergy(respawnEnergy);
    }
    public bool CheckRespawn(){
        if (respawnEnergy == respawnEnergyTotal)
            return true;
        return false;
    }
    
    public void IncreaseRespawnEnergy()
    {
        respawnEnergyTotal = respawnEnergy + (respawnEnergyTotal / 2);
    }

    //Power mechanic - power level scales up with score.
    // once hit a threshold upgrade the weapons.
    public int GetPowerLevel() { return powerLevel; }
    
    private void IncreasePowerLevel(int amount) 
    {
        powerLevelBarTotal = powerLevelBarTotal + ( powerLevelBarTotal / 4);
        hud.UpdatePowerLevelBarTotal(powerLevelBarTotal);
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
        hud.UpdatePowerLevelBar(powerLevelBar);
    }



    //Save / Pass stats off to the player

    //Setup wave of waves, once done spawn another set
    //award score


    void Awake()
    {
        hud = FindObjectOfType<HudController>();
        hud.UpdateRespawnEnergyTotal(respawnEnergyTotal);
        hud.UpdatePowerLevelBar(powerLevelBar);
        hud.UpdatePowerLevelBarTotal(powerLevelBarTotal);
    }
}
