using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile, WithAll(typeof(Player))]
public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;
    public float Horizontal;
    public float Vertical;
    
    void Execute(ref LocalTransform transform, in Velocity velocity)
    {
        transform.Position += transform.Right() * velocity.Value * Horizontal * DeltaTime;
        transform.Position += transform.Forward() * velocity.Value * Vertical * DeltaTime;
    }
}