using Unity.Entities;

public class SteeringVelocityBaker : Baker<SteeringVelocityAuthoring>
{
    public override void Bake(SteeringVelocityAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new SteeringVelocity {Value = authoring.Value});
    }
}