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
        return Vector3.ProjectOnPlane(direction, target.up).normalized;
    }

    //public static Vector3 Direction(Vector3 from, Vector3 to)
    //{
    //    return (to - from).normalized;
    //}

    public static SixWayDirections Direction(Transform transform, Vector3 target)
    {
        Vector3 dots = new Vector3();

        Vector3 dirToTarget = transform.DirectionTo(target);

        dots.z = Vector3.Dot(transform.forward, dirToTarget);
        dots.x = Vector3.Dot(transform.right, dirToTarget);
        dots.y = Vector3.Dot(transform.up, dirToTarget);

        SixWayDirections sixWayDirections = new SixWayDirections();

        if (dots.x > 0.5f)
        {
            sixWayDirections = SixWayDirections.Right;
        }
        else if (dots.x < -0.5f)
        {
            sixWayDirections = SixWayDirections.Left;
        }
        else
        {
            if (dots.y > 0.5f)
            {
                sixWayDirections = SixWayDirections.Up;
            }
            else if (dots.y < -0.5f)
            {
                sixWayDirections = SixWayDirections.Down;
            }
            else
            {
                if (dots.z > 0.5f)
                {
                    sixWayDirections = SixWayDirections.Front;
                }
                else if (dots.z < -0.5f)
                {
                    sixWayDirections = SixWayDirections.Back;
                }
            }
        }

        return sixWayDirections;
    }

    public static SixWayDirections InverseDirection(Transform transform, Vector3 target)
    {
        Vector3 dots = new Vector3();

        Vector3 dirToTarget = transform.DirectionTo(target);

        dots.z = Vector3.Dot(-transform.forward, dirToTarget);
        dots.x = Vector3.Dot(-transform.right, dirToTarget);
        dots.y = Vector3.Dot(-transform.up, dirToTarget);

        SixWayDirections sixWayDirections = new SixWayDirections();

        if (dots.x > 0.5f)
        {
            sixWayDirections = SixWayDirections.Right;
        }
        else if (dots.x < -0.5f)
        {
            sixWayDirections = SixWayDirections.Left;
        }
        else
        {
            if (dots.y > 0.5f)
            {
                sixWayDirections = SixWayDirections.Up;
            }
            else if (dots.y < -0.5f)
            {
                sixWayDirections = SixWayDirections.Down;
            }
            else
            {
                if (dots.z > 0.5f)
                {
                    sixWayDirections = SixWayDirections.Front;
                }
                else if (dots.z < -0.5f)
                {
                    sixWayDirections = SixWayDirections.Back;
                }
            }
        }

        return sixWayDirections;
    }
}
