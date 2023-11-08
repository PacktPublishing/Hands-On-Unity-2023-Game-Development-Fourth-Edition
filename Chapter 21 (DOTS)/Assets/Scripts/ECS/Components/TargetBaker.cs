using Unity.Entities;

public class TargetBaker : Baker<TargetAuthoring>
{
    public override void Bake(TargetAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        var targetEntity = GetEntity(authoring.Value, TransformUsageFlags.Dynamic);
        AddComponent(entity, new Target {Value = targetEntity});
    }
}