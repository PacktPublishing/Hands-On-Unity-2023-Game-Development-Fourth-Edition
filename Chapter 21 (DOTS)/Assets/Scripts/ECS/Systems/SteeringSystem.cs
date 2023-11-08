using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct SteeringSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var job = new SteeringJob();
        job.DeltaTime = SystemAPI.Time.DeltaTime;
        job.TransformLookup = SystemAPI.GetComponentLookup<LocalToWorld>(true);
        job.ScheduleParallel();
    }
}

