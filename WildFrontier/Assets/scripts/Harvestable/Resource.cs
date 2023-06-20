// script for defining what a resource is in our game world
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "WildFrontier/Resource")]
public class Resource : ScriptableObject
{
    [SerializeField] public int item_id;
    [SerializeField] public string item_name;
    [SerializeField] public Sprite icon;
}
