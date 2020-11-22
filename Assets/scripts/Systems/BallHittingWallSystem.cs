using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using UnityEngine.SceneManagement;


public class BallHittingWallSystem : ReactiveSystem<GameEntity>
{
    [SerializeField]
    string LevelName = "menu";

    private Contexts _contexts;

    public BallHittingWallSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var first = entity.collision.first;
            var second = entity.collision.second;
            var firstEntity = _contexts.game.GetEntitiesWithView(first).SingleEntity();
            var firstEntityTransform = firstEntity.view.value.transform;
            var move = firstEntityTransform.up;

            var accelerationX = firstEntity.acceleration.value.x;
            var accelerationY = firstEntity.acceleration.value.y;

            if (second.name == "buttonDefault_left" || second.name == "buttonDefault_right")
            {
                firstEntity.ReplaceAcceleration(new Vector3(accelerationX * (-1), accelerationY, 0f));
            }
            else if (second.name == "buttonDefault_bottom" || second.name == "paddle(Clone)")
            {
                firstEntity.ReplaceAcceleration(new Vector3(accelerationX, accelerationY * (-1), 0f));
            }
            else if(second.name == "DeadZone(Clone)")
            {
                SceneManager.LoadScene(LevelName);
            }
            else
            {
                var secondEntity = _contexts.game.GetEntitiesWithView(second).SingleEntity();
                secondEntity.isDestroy = true;
                firstEntity.ReplaceAcceleration(new Vector3(accelerationX, accelerationY * (-1), 0f));
            }
            
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }
}
