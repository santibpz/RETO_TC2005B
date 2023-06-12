// script for defining an enemy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "WildFrontier/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] public Weapon usedWeapon;
    [SerializeField] public int health = 100;
}
