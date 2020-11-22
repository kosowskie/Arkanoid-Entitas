using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class InputCompontent : IComponent
{
    public Vector3 value;
}