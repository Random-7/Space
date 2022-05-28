using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Slider HealthBar;
    [SerializeField] GameObject ShieldBar;
    [SerializeField] GameObject RespawnBar;
    [SerializeField] GameObject PowerBar;
    [SerializeField] Player player;
    [SerializeField] Game game;
    // Start is called before the first frame update
    void Start()
    {
        var gameObject = GameObject.Find("Game");
        game = gameObject.GetComponent<Game>();

        var playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayer(Player newPlayer)
    {
        player = newPlayer;
    }

    public void UpdateHealth(int amount)
    {
        HealthBar.value = amount;
    }
    public void UpdateMaxHealth(int amount)
    {
        HealthBar.maxValue = amount;
    }


}
