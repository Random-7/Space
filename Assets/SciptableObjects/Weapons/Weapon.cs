using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] List<GameObject> ProjectilePrefabs;

    [SerializeField] float FireRate = 1.0f;
    [SerializeField] float ProjectileSpeed = 1.0f;
    [SerializeField] int PowerModifer = 1;
    [SerializeField] int Damage = 1;
    [SerializeField] float DamgeRadius = 0.0f;

    public GameObject GetCurrentProjectilePrefab() 
    {
        switch (PowerModifer)
        {
            case 1:
               return ProjectilePrefabs[0];
            case 2:
                return ProjectilePrefabs[1];
            case 3:
                return ProjectilePrefabs[2];
            case 4:
                return ProjectilePrefabs[3];
            default:
                return ProjectilePrefabs[0];
        }
    }
    public float GetFireRate() 
    { 
         return FireRate; 
    }
    public float GetProjectileSpeed() 
    { 
        return ProjectileSpeed * PowerModifer;
    }
    public int GetDamage()
    { 
        return Damage * PowerModifer; 
    }
    public float GetDamageRadius()
    { 
        return DamgeRadius;
    }

    public void SetPowerModifer(int amount)
    {
        PowerModifer = amount;
    }
    public void IncreasePowerModifer(int amount)
    {
        PowerModifer += amount;
    }
}

