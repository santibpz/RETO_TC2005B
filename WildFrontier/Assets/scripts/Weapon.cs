// script for the definition of a weapon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WildFrontier/Weapon")]

public class Weapon : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] string type;
    [SerializeField] int woodRequirement;
    [SerializeField] int rockRequirement;
    [SerializeField] int damage;
    [SerializeField] int speed;
    [SerializeField] int reload;
    [SerializeField] Sprite icon;

}
