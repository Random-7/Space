using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
    Health
        take damage
        check if damage is lethal
        Destroy
    Weapon
        what weapon
        Set weapon
    Game
        Add score
        Drop Item?
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(int amount) 
    {
        print(gameObject.name + " Got hit for: " + amount);
    }
}
