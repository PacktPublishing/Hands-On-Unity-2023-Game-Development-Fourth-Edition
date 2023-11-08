using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct DestroyCloseTargetJob : IJobEntity
{
    private const float DestroyDistanceSqr = 0.7f * 0.7f;
        
    [ReadOnly] public ComponentLookup<LocalToWorld> TransformLookup;

    public EntityCommandBuffer.ParallelWriter ECB;

    void Execute(ref LocalTransform transform, in Target target)
    {
        if (target.Value == Entity.Null ||
            !TransformLookup.TryGetComponent(target.Value, out var targetTransform))
            return;

        var distSqr = math.lengthsq(targetTransform.Position - transform.Position);
        
        if (distSqr < DestroyDistanceSqr)
        {
            ECB.DestroyEntity(0, target.Value);
        }
    }
}