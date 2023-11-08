using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct CameraFollowSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        if (SystemAPI.TryGetSingletonEntity<Player>(out var playerEntity))
        {
            var playerTransform = SystemAPI.GetComponent<LocalToWorld>(playerEntity);
            Camera.main.transform.position = playerTransform.Position + new float3(0, 10, 0);
        }
    }
}

