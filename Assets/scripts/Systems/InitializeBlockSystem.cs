using Entitas;
using UnityEngine;

public class InitializeBlockSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeBlockSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        int height = _contexts.game.gameSetups.value.height;
        int width = _contexts.game.gameSetups.value.width;
        int multiplication = height * width;

        for (int i = 0; i < multiplication; i++)
        {
                int index = Random.Range(0, 4);
                var entity = _contexts.game.CreateEntity();
                entity.isBlock = true;
                entity.AddResource(_contexts.game.gameSetups.value.block[index]);

                int x = i % width;
                int y = i / width; 
                entity.AddInitialPosition(new Vector3((x - 2.5f) * 2f, (y - 0.5f) * 1.2f, 0f));
        }
    }
}
