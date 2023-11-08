using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


[BurstCompile]
public partial struct SteeringJob : IJobEntity
{
    [ReadOnly] public ComponentLookup<LocalToWorld> TransformLookup;
    public float DeltaTime;

    void Execute(ref LocalTransform transform, in Velocity velocity,
        in SteeringVelocity steeringVelocity, in Target target)
    {
        if (target.Value == Entity.Null ||
            !TransformLookup.TryGetComponent(target.Value, out var targetTransform))
            return;
        
        var direction = targetTransform.Position - transform.Position;
        var rotation = quaternion.LookRotation(direction, transform.Up());
        ///...

        transform.Rotation = math.nlerp(transform.Rotation, rotation,
            steeringVelocity.Value * DeltaTime);

        transform.Position += transform.Forward() * velocity.Value * DeltaTime;
    }
}

