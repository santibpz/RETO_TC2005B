// // script for creating new asset menu for a tool type

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolType", menuName = "WildFrontier/ToolType")]
public class ToolType : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] public Sprite icon;
}
