using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;


public class BallHittingDeadZone : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public BallHittingDeadZone(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {

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
