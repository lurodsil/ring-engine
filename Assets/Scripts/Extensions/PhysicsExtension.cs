public class PhysicsExtension
{
    public static float Velocity(float distance, float time)
    {
        return distance / time;
    }

    public static float Distance(float velocity, float time)
    {
        return velocity * time;
    }

    public static float Time(float distance, float velocity)
    {
        return distance / velocity;
    }
}
