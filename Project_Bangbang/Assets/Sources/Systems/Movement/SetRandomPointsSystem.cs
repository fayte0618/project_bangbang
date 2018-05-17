using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SetRandomPointsSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;

    public SetRandomPointsSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.RandomPath);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasRandomPath;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            var numPts = Random.Range(e.randomPath.numPoints.min, e.randomPath.numPoints.max);
            PointData[] points = new PointData[numPts];
            for (int i = 0; i < numPts; i++)
            {
                var newPos = _meta.screenService.current.RandomPoint();
                points[i] = new PointData()
                {
                    position = newPos,
                    rotation = e.randomPath.includeRotation ? Random.insideUnitSphere * 360f : Vector3.zero,
                    duration = Random.Range((float)e.randomPath.duration.min, (float)e.randomPath.duration.max)
                };
            }

            e.ReplacePath(points);
        }
    }
}