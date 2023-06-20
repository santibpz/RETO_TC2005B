
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeapon : MonoBehaviour
{
    [SerializeField] Message message;
    [SerializeField] GameObject currentWeaponUI;
    [SerializeField] Image weaponImg;
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
        if(_weapon != null)
        {
            attack.weaponToUse = _weapon;
            message.Send($"{_weapon.name} Equipped!");
            currentWeaponUI.SetActive(true);
            weaponImg.sprite = _weapon.icon;
        }

        
    }
}
