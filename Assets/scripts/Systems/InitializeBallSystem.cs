using Entitas;
using UnityEngine;

public class InitializeBallSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeBallSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isBall = true;
        entity.AddResource(_contexts.game.gameSetups.value.ball);
        entity.AddInitialPosition(new Vector3(0f, -3f, 0f));

        var randomAngle = Random.Range(0f, 2f);
        var speed = _contexts.game.gameSetups.value.ballSpeed;

        entity.AddAcceleration(new Vector3(
            speed * Mathf.Cos(randomAngle),
            speed * Mathf.Sin(randomAngle), 0f));
    }
}
