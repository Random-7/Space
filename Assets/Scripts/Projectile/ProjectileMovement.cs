using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] public bool IsEnemyProjectile = false;
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "Enemy")
        {
            var enemy = col.GetComponent<Enemy>();
            enemy.TakeHit(weapon.GetDamage());
            print("Enemy named: " + col.gameObject.name + " Takes hit for: " + weapon.GetDamage());

        } else if (col.gameObject.tag == "Player")
        {
            var player = col.GetComponent<Player>();
            player.TakeHit(weapon.GetDamage());
            print("Player Takes hit for: " + weapon.GetDamage());
        } else if (col.gameObject.tag == "Shreddar")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(!IsEnemyProjectile)
            gameObject.layer = LayerMask.NameToLayer("Player");
        else
            gameObject.layer = LayerMask.NameToLayer("Enemy");

    }
    // Update is called once per frame
    void Update()
    {
        if(!IsEnemyProjectile)
            transform.position +=  new Vector3(0,1,0) * Time.deltaTime * weapon.GetProjectileSpeed();
        else
            transform.position +=  new Vector3(0,-1,0) * Time.deltaTime * weapon.GetProjectileSpeed();
    }
}
