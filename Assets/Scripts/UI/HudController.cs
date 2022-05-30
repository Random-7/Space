using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Slider HealthBar;
    [SerializeField] Slider RespawnBar;
    [SerializeField] Slider PowerBar;
    [SerializeField] Game game;

    // Start is called before the first frame update
    void Start()
    {
        var gameObject = GameObject.Find("Game");
        game = gameObject.GetComponent<Game>();
    }

    public void UpdateHealth(int amount)
    {
        HealthBar.value = amount;
    }
    public void UpdateMaxHealth(int amount)
    {
        HealthBar.maxValue = amount;
    }

    public void UpdateRespawnEnergy(int amount)
    {
        RespawnBar.value = amount;
    }
    public void UpdateRespawnEnergyTotal(int amount)
    {
        RespawnBar.maxValue = amount;
    }

    public void UpdatePowerLevelBar(int amount)
    {
        PowerBar.value = amount;
    }
    public void UpdatePowerLevelBarTotal(int amount)
    {
        PowerBar.maxValue = amount;
    }


}
