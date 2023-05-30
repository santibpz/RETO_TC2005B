
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public Weapon weapon
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
                //UpdateSprite();
            }
        }
    }

    [SerializeField] public Weapon _weapon;
    [SerializeField] Attack attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipWeaponToUse()
    {
        attack.weaponToUse = _weapon;
    }
}
