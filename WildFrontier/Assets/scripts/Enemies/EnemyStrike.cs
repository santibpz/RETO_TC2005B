// script for controlling damage caused by an enemy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrike : MonoBehaviour
{
    [SerializeField] Weapon strikingWeapon;
    private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject attacker;

    private int enemyDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = strikingWeapon.icon;
        enemyDamage = strikingWeapon.damage / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KnockBack knockBack = collision.gameObject.GetComponent<KnockBack>();
            knockBack.AddKnockBack(attacker);
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.health -= enemyDamage;
            player.healthBar.UpdateHealthBar(player.health, 100);
            Debug.Log($"Player health is {player.health}");
        } else if(collision.gameObject.CompareTag("Wolf"))
        {
            WolfAgentMovement wolf = collision.gameObject.GetComponent<WolfAgentMovement>();
            wolf.health -= enemyDamage;
            wolf.healthBar.UpdateHealthBar(wolf.health, 100);
            Debug.Log($"wolfie health is {wolf.health}");
        }
    }

}
