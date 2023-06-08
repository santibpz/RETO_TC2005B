// script for the definition of a weapon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WildFrontier/Weapon")]

public class Weapon : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] string type;
    [SerializeField] public int woodRequirement;
    [SerializeField] public int rockRequirement;
    [SerializeField] public int damage;
    [SerializeField] int speed;
    [SerializeField] int reload;
    [SerializeField] public Sprite icon;

}
