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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateSprite()
    {
        
            spriteRenderer.sprite = _weapon.icon;
        
    }
}
