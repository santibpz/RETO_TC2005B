using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Weapon weaponToUse
    {
        get
        {
            return _weapon;
        }
        set
        {
            if (_weapon != value)
            {
                _weapon = value;
                // update the sprite
                UpdateSprite();
            }
        }
    }

    [SerializeField] public Weapon _weapon;
    private SpriteRenderer spriteRenderer;

    private int weaponDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if(_weapon != null) weaponDamage = _weapon.damage;
    }

    private void UpdateSprite()
    {

        if (_weapon != null)
        {
            spriteRenderer.sprite = _weapon.icon;

        }
        else
        {
            spriteRenderer.sprite = null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("entered");
            KnockBack knockBack = collision.gameObject.GetComponent<KnockBack>();
            knockBack.AddKnockBack(GameObject.FindGameObjectWithTag("Player"));
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            enemyController.health -= weaponDamage;
            Debug.Log($" {_weapon.name} damage is: {weaponDamage}");
            Debug.Log($"{enemyController.enemy.name} enemey new health is: {enemyController.health}");
        }
    }
}
