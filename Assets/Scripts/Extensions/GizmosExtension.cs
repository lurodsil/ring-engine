using UnityEngine;

public static class GizmosExtension
{
    public static void DrawTrajectory(Vector3 origin, Vector3 direction, float velocity, float length)
    {
        Vector3 vel = direction * velocity;
        Vector3 pos = origin;
        Vector3 lastPos = origin;
        float precision = 0.01f;

        for (float t = 0f; t < length; t += precision)
        {
            vel.y += (Physics.gravity.y * precision);
            pos += vel * precision;
            Gizmos.DrawLine(lastPos, pos);
            lastPos = pos;
        }
    }

    public static void DrawTrajectory(Vector3 origin, Vector3 direction, float velocity, float length, float keepVelocityDistance)
    {
        float duration = PhysicsExtension.Time(keepVelocityDistance, velocity);
        float outOfControl = Mathf.Clamp(PhysicsExtension.Distance(length, velocity), 0, keepVelocityDistance);
        Gizmos.DrawRay(origin, direction * outOfControl);
        DrawTrajectory(origin + (direction * keepVelocityDistance), direction, velocity, length - duration);
    }

    public static void DrawViewRange(Vector3 origin, Vector3 direction, float angle, float range)
    {
        float viewAngleRad = angle / 2 * Mathf.Deg2Rad;

        Vector3 leftDirection = Vector3.RotateTowards(direction, -direction, viewAngleRad, 1);
        Vector3 rightDirection = Vector3.RotateTowards(direction, -direction, -viewAngleRad, 1);

        Gizmos.DrawRay(origin, leftDirection * range);
        Gizmos.DrawRay(origin, rightDirection * range);
    }
}