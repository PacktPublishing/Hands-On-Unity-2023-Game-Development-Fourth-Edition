using Unity.Entities;
using UnityEngine;

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Spawner {
            Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            Target = GetEntity(authoring.target, TransformUsageFlags.Dynamic),
            Amount = authoring.amount,
            Frequency = authoring.frequency,
        });
    }
}