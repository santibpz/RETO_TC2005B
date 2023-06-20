// script for creating new asset menu for a tool
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "WildFrontier/Tool")]

public class Tool : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] Sprite icon;
    [SerializeField] public ToolType type;

    [SerializeField] public Sprite Sprite;
}
