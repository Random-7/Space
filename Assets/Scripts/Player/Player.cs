using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] float Speed = 5.0f;
    [SerializeField] float BoostAmount = 2.0f;


    public float GetSpeed() { return Speed; }
    public float GetBoostAmount() { return BoostAmount; }
    
}
