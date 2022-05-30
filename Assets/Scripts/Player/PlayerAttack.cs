using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Weapon PrimaryWeapon;
    [SerializeField] Weapon SecondaryWeapon;
    [SerializeField] Transform Fire1Spawn;
    [SerializeField] Transform Fire2Spawn1;
    [SerializeField] Transform Fire2Spawn2;

    [SerializeField] Weapon[] Weapons;

    bool Firing1 = false;
    bool Firing2 = false;

    float fire1Timer = 0.0f;
    float fire2Timer = 0.0f;

    void Start()
    {
        PrimaryWeapon = Weapons[0];
        SecondaryWeapon = Weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        fire1Timer += Time.deltaTime;
        fire2Timer += Time.deltaTime;

        //Get Firerate from Player class.
        if(Firing1 && fire1Timer > PrimaryWeapon.GetFireRate()) {
            Instantiate(PrimaryWeapon.GetCurrentProjectilePrefab(), Fire1Spawn.position, Quaternion.identity);
            fire1Timer = 0.0f;
        }
        if(Firing2 && fire2Timer > SecondaryWeapon.GetFireRate()) {
            Instantiate(SecondaryWeapon.GetCurrentProjectilePrefab(), Fire2Spawn1.position, Quaternion.identity);
            Instantiate(SecondaryWeapon.GetCurrentProjectilePrefab(), Fire2Spawn2.position, Quaternion.identity);
            fire2Timer = 0.0f;
        }

    }

    public void Fire1(bool firing)
    {
       Firing1 = firing;
    }

    public void Fire2(bool firing)
    {
       Firing2 = firing;
    }

    public void UgradeWeapons(int upgrade) 
    {
        PrimaryWeapon = Weapons[upgrade];
        SecondaryWeapon = Weapons[upgrade];
    }
}
