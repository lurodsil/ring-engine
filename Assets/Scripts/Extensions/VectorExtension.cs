using UnityEngine;

public enum SixWayDirections
{
    Up,
    Down,
    Left,
    Right,
    Front,
    Back
}

public class VectorExtension
{
    public static Vector3 InputDirection(float inputX, float inputY)
    {
        return InputDirection(inputX, inputY, Camera.main.transform, Vector3.up);
    }

    public static Vector3 InputDirection(float inputX, float inputY, Vector3 upwards)
    {
        return InputDirection(inputX, inputY, Camera.main.transform, upwards);
    }

    public static Vector3 InputDirection(float inputX, float inputY, Transform camera)
    {
        return InputDirection(inputX, inputY, camera, Vector3.up);
    }

    public static Vector3 InputDirection(float inputX, float inputY, Transform camera, Vector3 upwards)
    {
        Vector3 input = new Vector3(inputX, 0, inputY);
        Quaternion rotation = Quaternion.LookRotation(camera.forward, upwards);
        Vector3 direction = rotation * input;

        return Vector3.ProjectOnPlane(direction, upwards).normalized;
    }

    public static Vector3 InputDirection(float inputX, float inputY, Transform camera, Transform target)
    {
        Vector3 input = new Vector3(inputX, 0, inputY);
        Vector3 direction = camera.TransformDirection(input);
        direction.y = target.TransformDirection(input).y;
        return Vector3.ProjectOnPlane(direction, target.up);
    }

    public static Vector3 GetMovementDirectionProjectedOnPlane(Transform character, Vector2 input, Vector3 groundNormal)
    {
        Vector3 inputDirection =
            character.forward * input.y +
            character.right * input.x;

        Vector3 movement = Vector3.ProjectOnPlane(inputDirection, groundNormal);

        return movement.normalized;
    }



    public static SixWayDirections Direction(Transform transform, Vector3 target)
    {
        Vector3 dir = (target - transform.position).normalized;

        float x = Vector3.Dot(transform.right, dir);
        float y = Vector3.Dot(transform.up, dir);
        float z = Vector3.Dot(transform.forward, dir);

        float ax = Mathf.Abs(x);
        float ay = Mathf.Abs(y);
        float az = Mathf.Abs(z);

        if (ax > ay && ax > az)
            return x > 0 ? SixWayDirections.Right : SixWayDirections.Left;

        if (ay > ax && ay > az)
            return y > 0 ? SixWayDirections.Up : SixWayDirections.Down;

        return z > 0 ? SixWayDirections.Front : SixWayDirections.Back;
    }
}
