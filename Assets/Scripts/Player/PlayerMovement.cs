using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    [SerializeField] float Speed = 5.0f;
    [SerializeField] float BoostAmount = 2.0f;

    Vector2 movementDir;
    float boost = 1.0f;

    void SetBoostAmount(float diff) { BoostAmount += diff; }

    public void ApplyBoost() 
    { 
        boost += BoostAmount;
        print(boost);
    }
    public void RemoveBoost() 
    { 
        boost = 1.0f; 
        print(boost);
    }
    // Update is called once per frame
    void Update()
    {
        var MovementAndSpeed = (movementDir * Speed * boost) * Time.deltaTime;
        transform.Translate(MovementAndSpeed, Space.World);
    }

    public void MovementDirection(float x, float y)
    {
       movementDir = new Vector2(x, y).normalized;
    }
}
