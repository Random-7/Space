using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float fire1Rate = 1.0f;
    [SerializeField] float fire2Rate = 1.0f;
    [SerializeField] float Speed = 5.0f;
    [SerializeField] float BoostAmount = 2.0f;
    [SerializeField] Transform[] Path;

    public float GetFire1Rate() { return fire1Rate; }
    public float GetFire2Rate() { return fire2Rate; }

    public float GetSpeed() { return Speed; }
    public float GetBoostAmount() { return BoostAmount; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
