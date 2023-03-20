using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public float shootInterval;
    public float fireballSpeed;
    public Vector3 fireballPosition;

    public GameObject fireballPrefab;
    public Transform target;

    private float timer = 0f;
    
    

    public BossHealth healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        if (contact.normal.y>.5)
        {
            TakeDamage();
            if (currentHealth <= 0)
            {
                // Boss is defeated
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > shootInterval)
        {
            ShootProjectile();
            timer = 0f;
        }
    }

    void ShootProjectile()
    {
        Debug.Log("Shooting projectile!");

        // Instantiate the projectile prefab at the boss's position
        GameObject projectile = Instantiate(fireballPrefab, transform.position + fireballPosition, Quaternion.identity);

        // Set the projectile's velocity to go in the direction of the player (or some other target)
        Vector2 direction = (target.position - (transform.position + fireballPosition)).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;

        // Set the projectile's owner to the boss GameObject
        projectile.GetComponent<FireballCollision>().owner = gameObject;
    }

    void TakeDamage()
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}