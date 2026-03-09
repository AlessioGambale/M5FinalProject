using System.Collections.Generic;
using UnityEngine;

public abstract class SO_Effect : ScriptableObject
{
    public abstract void Apply(GameObject user);
}
