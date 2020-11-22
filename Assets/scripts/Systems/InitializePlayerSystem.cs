using Entitas;
using UnityEngine;

public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        entity.AddResource(_contexts.game.gameSetups.value.player);
        entity.AddInitialPosition(new Vector3(0f, -4f, 0f));
        entity.AddAcceleration(Vector3.zero);
    }
}
