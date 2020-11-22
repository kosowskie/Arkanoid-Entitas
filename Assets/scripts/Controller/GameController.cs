using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    public GameSetups gameSetups;

    private Systems _systems;

    // Start is called before the first frame update
    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        /* var entity = contexts.game.CreateEntity();
        entity.AddGameSetups(gameSetups); */

        contexts.game.SetGameSetups(gameSetups);

        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InitializeBallSystem(contexts))
            .Add(new InitializeBlockSystem(contexts))
            .Add(new InitializeDeadZoneSystem(contexts))
            .Add(new InputSystem(contexts))
            .Add(new BallHittingWallSystem(contexts))

            .Add(new InstantiateViewSystem(contexts))
            
            .Add(new PlayerMovementSystem(contexts))
            .Add(new MoveSystem(contexts))

            .Add(new DestroySystem(contexts))
            ;
    }
}