using Unity.Burst;
using Unity.Entities;

public partial struct SpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Player>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecbSystem = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
        var ecb = ecbSystem.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
            
        var job = new SpawnerJob();
        job.Time = (float) SystemAPI.Time.ElapsedTime;
        job.ECB = ecb;
        job.ScheduleParallel();
    }
}