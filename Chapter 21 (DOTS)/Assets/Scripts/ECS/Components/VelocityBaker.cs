using Unity.Entities;

public class VelocityBaker : Baker<VelocityAuthoring>
{
    public override void Bake(VelocityAuthoring authoringComponent)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        var runtimeComponent = new Velocity();
        runtimeComponent.Value = authoringComponent.value;
        AddComponent(entity, runtimeComponent);
    }
}