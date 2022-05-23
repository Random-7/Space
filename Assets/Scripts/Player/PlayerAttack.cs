using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject Fire1Projectile;
    [SerializeField] GameObject Fire2Projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire1()
    {
        print("fire");
        Instantiate(Fire1Projectile, transform.position, Quaternion.identity);
    }

    public void Fire2()
    {
        print("Fire2");
    }
}
