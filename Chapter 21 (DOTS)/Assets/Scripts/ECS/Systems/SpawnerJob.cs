using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
public partial struct SpawnerJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter ECB;
    public float Time;

    void Execute(ref Spawner spawner)
    {
        var timeSinceLastSpawn = Time - spawner.LastSpawnTime;
        if (timeSinceLastSpawn < spawner.Frequency)
            return;
        
        spawner.LastSpawnTime = Time;
        var instances = new NativeArray<Entity>(spawner.Amount, Allocator.Temp);
        ECB.Instantiate(0, spawner.Prefab, instances);

        for (var i = 0; i < spawner.Amount; i++)
        {
            var instance = instances[i];
            var transform = LocalTransform.FromPosition(i * 5, 0, 10);
            ECB.SetComponent(0, instance, transform);
            ECB.SetComponent(0, instance, new Target {Value = spawner.Target});
        }
    }
}


