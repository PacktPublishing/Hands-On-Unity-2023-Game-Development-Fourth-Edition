using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct DestroyCloseTargetSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSystem = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSystem.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
        
        var job = new DestroyCloseTargetJob();
        job.TransformLookup = SystemAPI.GetComponentLookup<LocalToWorld>(true);
        job.ECB = ecb;
        job.ScheduleParallel();
    }
}