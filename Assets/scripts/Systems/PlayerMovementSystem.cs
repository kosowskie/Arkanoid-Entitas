using Entitas;
using UnityEngine;

public class PlayerMovementSystem : IExecuteSystem
{
    private Contexts _contexts;

    [SerializeField]
    float MaxPosition = 5f;

    public PlayerMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var input = _contexts.game.inputCompontent.value.x;
        var player = _contexts.game.playerEntity;
        var playerTransform = player.view.value.transform;
        var move = playerTransform.right;

        var movementSpeed = _contexts.game.gameSetups.value.playerMovementSpeed;

        var acceleration = player.acceleration.value;

        player.ReplaceAcceleration(input * move * 3);

        var positionX = Mathf.Clamp(playerTransform.position.x, -MaxPosition, MaxPosition);
        playerTransform.position = new Vector3(positionX, playerTransform.position.y);
    }
}
