using UnityEngine;


namespace RingEngine
{
    public enum SixWayDirections
    {
        Up,
        Down,
        Left,
        Right,
        Front,
        Back
    }

    public struct Vector3Extension
    {
        public static Vector3 Direction(Vector3 from, Vector3 to)
        {
            return (to - from).normalized;
        }

        public static SixWayDirections Direction(Transform transform, Vector3 target)
        {
            Vector3 dots = new Vector3();

            Vector3 dirToTarget = Direction(transform.position, target);

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

            Vector3 dirToTarget = Direction(transform.position, target);

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

    public class Tasks
    {

        static float lastStateTime;
        static bool returnBool;

        static float velocity;
        static Vector3 vel;
        static Vector3 previous;

        public static float GetTransformVelocity(Transform transform)
        {
            velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
            previous = transform.position;
            return velocity;
        }

        public static Vector3 GetTransformVelocityVector(Transform transform)
        {
            vel = (transform.position - previous);
            previous = transform.position;
            return vel;
        }


        public static void ChangeMouthSide(Transform target, Transform leftMouth, Transform rightMouth)
        {
            if (Vector3.Dot(target.right, Camera.main.transform.forward) < 0)
            {
                leftMouth.localScale = Vector3.zero;
                rightMouth.localScale = Vector3.one;
            }
            else
            {
                leftMouth.localScale = Vector3.one;
                rightMouth.localScale = Vector3.zero;
            }
        }
    }

    public struct MathfExtension
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

        /// <summary>
        /// Convert two string values (x,y) to a Vector2
        /// </summary>
        public static Vector2 Parse(string x, string y)
        {
            return new Vector2(float.Parse(x), float.Parse(y));
        }

        /// <summary>
        /// Convert three string values (x,y,z) to a Vector3.
        /// </summary>
        public static Vector3 Parse(string x, string y, string z)
        {
            return new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));
        }

        public static Vector3 StickDirection(float x, float y)
        {
            Vector3 stickDirection = new Vector3(x, 0, y);
            return stickDirection.normalized;
        }

        public static Vector3 StickDirection(float x, float y, Transform RelativeTo)
        {
            Vector3 stickDirection = new Vector3(x, 0, y);
            stickDirection = RelativeTo.TransformDirection(stickDirection);
            return stickDirection.normalized;
        }

        public static Vector3 StickDirection(float x, float y, Transform RelativeTo, Transform target)
        {
            Vector3 stickDirection = new Vector3(x, 0, y);
            stickDirection = RelativeTo.TransformDirection(stickDirection);
            stickDirection.y = target.forward.y;
            return stickDirection.normalized;
        }
    }

    public static class ExtensionMethods
    {
        private static Vector3 previous;
        private static Vector3 velocity;

        public static Vector3 Velocity(this Transform transform)
        {
            velocity = (transform.position - previous) / Time.deltaTime;
            previous = transform.position;

            return velocity;
        }

        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localPosition = Vector3.zero;

            transform.rotation = Quaternion.identity;
            transform.localRotation = Quaternion.identity;

            transform.localScale = Vector3.one;
        }

        public static void CopyTransform(this Transform source, Transform target)
        {
            source.position = target.position;
            source.rotation = target.rotation;
            source.localScale = target.localScale;
        }

        public static Vector3 HorizontalVelocity(this Rigidbody rigidbody)
        {
            return new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        }
        public static Vector3 VerticalVelocity(this Rigidbody rigidbody)
        {
            return new Vector3(0, rigidbody.velocity.y, 0);
        }
        public static void Accelerate(this Rigidbody rigidbody, float acceleration, float maxVelocity)
        {
            Accelerate(rigidbody, acceleration, maxVelocity, false, rigidbody.transform.forward);
        }
        public static void Accelerate(this Rigidbody rigidbody, float acceleration, float maxVelocity, bool useGravity)
        {
            Accelerate(rigidbody, acceleration, maxVelocity, useGravity, rigidbody.transform.forward);
        }
        public static void Accelerate(this Rigidbody rigidbody, float acceleration, float maxVelocity, bool useGravity, Vector3 direction)
        {            
            if (useGravity)
            {
                Vector3 currentVelocity = rigidbody.velocity;

                currentVelocity = direction * Mathf.MoveTowards(HorizontalVelocity(rigidbody).magnitude, maxVelocity, acceleration * Time.deltaTime);

                currentVelocity.y = rigidbody.velocity.y;

                rigidbody.velocity = currentVelocity;
            }
            else
            {


                rigidbody.velocity = direction * Mathf.MoveTowards(rigidbody.velocity.magnitude, maxVelocity, acceleration * Time.deltaTime);
            }
        }

        public static void Decelerate(this Rigidbody rigidbody, float deceleration)
        {
            Accelerate(rigidbody, deceleration, 0);
        }
        public static void Decelerate(this Rigidbody rigidbody, float deceleration, bool useGravity)
        {
            Accelerate(rigidbody, deceleration, 0, useGravity);
        }
    }

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
            float duration = MathfExtension.Time(keepVelocityDistance, velocity);
            float outOfControl = Mathf.Clamp(MathfExtension.Distance(length, velocity), 0, keepVelocityDistance);
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
}