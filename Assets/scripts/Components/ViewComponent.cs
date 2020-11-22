using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ViewComponent : IComponent
{
    [EntityIndex]
    public GameObject value;
}