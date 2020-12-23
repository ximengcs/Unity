using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// Component only store data
/// </summary>
public struct LevelComponent : IComponentData
{
    public float level;  // level
}
