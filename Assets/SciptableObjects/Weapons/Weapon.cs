using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject ProjectilePrefab;

    [SerializeField] float FireRate = 1.0f;
    [SerializeField] float ProjectileSpeed = 1.0f;
    [SerializeField] int Damage = 1;
    [SerializeField] float DamgeRadius = 0.0f;

    public float GetFireRate() { return FireRate; }
    public float GetProjectileSpeed() { return ProjectileSpeed; }
    public int GetDamage() { return Damage; }

    public float GetDamageRadius() { return DamgeRadius; }
}

