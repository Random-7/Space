using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] public bool IsEnemyProjectile = false;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip FireSound;
    [SerializeField] AudioClip HitSound;
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "Enemy")
        {
            var enemy = col.GetComponent<Enemy>();
            enemy.TakeHit(weapon.GetDamage());
            audioSource.clip = HitSound;
            audioSource.Play();
            spriteRenderer.enabled = false;
            Destroy(gameObject, 0.4f);

        } else if (col.gameObject.tag == "Player")
        {
            var player = col.GetComponent<Player>();
            player.TakeHit(weapon.GetDamage());
            audioSource.clip = HitSound;
            audioSource.Play();
            spriteRenderer.enabled = false;
            Destroy(gameObject, 0.4f);
        } else if (col.gameObject.tag == "Shreddar")
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        audioSource.clip = FireSound;
        audioSource.Play();
    }
    void Start()
    {

        if(!IsEnemyProjectile)
            gameObject.layer = LayerMask.NameToLayer("Player");
        else
        {
            audioSource.pitch = 0.75f;
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }

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
