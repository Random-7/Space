using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Game game;

    Vector2 movementDir;
    float boost = 1.0f;

    public void ApplyBoost() 
    { 
        boost += player.GetBoostAmount();
    }
    public void RemoveBoost() 
    { 
        boost = 1.0f; 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var MovementAndSpeed = movementDir * game.GetPlayerSpeed() * boost * Time.fixedDeltaTime;
        transform.Translate(MovementAndSpeed, Space.World);

    }

    public void MovementDirection(float x, float y)
    {
       movementDir = new Vector2(x, y).normalized;
    }

    void Start()
    {
        game = FindObjectOfType<Game>();
    }
}
