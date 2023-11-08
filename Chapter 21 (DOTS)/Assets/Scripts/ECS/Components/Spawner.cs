using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public Entity Target;
    public int Amount;
    public float Frequency;
    public float LastSpawnTime;
}