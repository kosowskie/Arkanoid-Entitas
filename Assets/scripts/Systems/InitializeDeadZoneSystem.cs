using Entitas;
using UnityEngine;

public class InitializeDeadZoneSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeDeadZoneSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isDeadZone = true;
        entity.AddResource(_contexts.game.gameSetups.value.deadZone);
        entity.AddInitialPosition(new Vector3(0f, -6f, 0f));
    }
}
