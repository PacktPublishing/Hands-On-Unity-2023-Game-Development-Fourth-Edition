using Unity.Burst;
using Unity.Entities;
using UnityEngine;

public partial struct MovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var job = new MoveJob();
        job.DeltaTime = SystemAPI.Time.DeltaTime;
        job.Horizontal = Input.GetAxis("Horizontal");
        job.Vertical = Input.GetAxis("Vertical");
        job.ScheduleParallel();
    }
}