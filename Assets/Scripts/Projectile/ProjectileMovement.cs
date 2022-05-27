using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "Enemy")
        {
            var enemy = col.GetComponent<Enemy>();
            enemy.TakeHit(weapon.GetDamage());
            print("Enemy named: " + col.gameObject.name + " Takes hit for: " + weapon.GetDamage());

        } else if (col.gameObject.tag == "Shreddar")
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position +=  new Vector3(0,1,0) * Time.deltaTime * weapon.GetProjectileSpeed();
    }
}
