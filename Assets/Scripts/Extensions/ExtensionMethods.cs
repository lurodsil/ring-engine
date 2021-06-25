using UnityEngine;

public static class ExtensionMethods
{
    #region GameObject Extensions
    public static GameObject Closest(this GameObject gameObject, GameObject[] GameObjects, float minDistance, float maxDistance, bool ignoreCollisions)
    {
        GameObject closest = null;

        float distance = Mathf.Infinity;

        foreach (GameObject target in GameObjects)
        {
            Vector3 diff = target.transform.position - gameObject.transform.position;

            float curDistance = diff.magnitude;

            if (TestDistance(curDistance, distance, minDistance, maxDistance))
            {
                TestCollision(gameObject, ignoreCollisions, target, curDistance, ref closest, ref distance);
            }
        }
        return closest;
    }
    public static GameObject Closest(this GameObject gameObject, GameObject[] GameObjects, float minDistance, float maxDistance, bool ignoreCollisions, Vector3 forward, float angle)
    {
        GameObject closest = null;

        float distance = Mathf.Infinity;

        foreach (GameObject target in GameObjects)
        {
            Vector3 diff = target.transform.position - gameObject.transform.position;

            float curDistance = diff.magnitude;

            if (TestDistance(curDistance, distance, minDistance, maxDistance))
            {
                if (TestAngle(forward, diff, angle))
                {
                    TestCollision(gameObject, ignoreCollisions, target, curDistance, ref closest, ref distance);
                }
            }
        }
        return closest;
    }
    public static GameObject Closest(this GameObject gameObject, GameObject[] GameObjects, float minDistance, float maxDistance, bool ignoreCollisions, Vector3 forward, float angle, Vector3 cameraForward, float cameraAngle, LayerMask layerMask)
    {
        GameObject closest = null;

        float distance = Mathf.Infinity;

        foreach (GameObject target in GameObjects)
        {
            Vector3 diff = target.transform.position - gameObject.transform.position;

            float curDistance = diff.magnitude;

            if (TestDistance(curDistance, distance, minDistance, maxDistance))
            {
                if (TestAngle(forward, diff, angle) && TestAngle(cameraForward, diff, cameraAngle))
                {
                    TestCollision(gameObject, ignoreCollisions, target, curDistance, ref closest, ref distance, layerMask);
                }
            }
        }
        return closest;
    }
    private static void TestCollision(GameObject gameObject, bool ignoreCollisions, GameObject target, float curDistance, ref GameObject closest, ref float distance)
    {
        if (ignoreCollisions)
        {
            closest = target;

            distance = curDistance;
        }
        else
        {
            if (!Physics.Linecast(gameObject.transform.position, target.transform.position))
            {
                closest = target;

                distance = curDistance;
            }
        }
    }
    private static void TestCollision(GameObject gameObject, bool ignoreCollisions, GameObject target, float curDistance, ref GameObject closest, ref float distance, LayerMask layerMask)
    {
        if (ignoreCollisions)
        {
            closest = target;

            distance = curDistance;
        }
        else
        {
            if (!Physics.Linecast(gameObject.transform.position, target.transform.position, layerMask))
            {
                closest = target;

                distance = curDistance;
            }
        }
    }
    private static bool TestDistance(float curDistance, float distance, float minDistance, float maxDistance)
    {
        return curDistance < distance && curDistance > minDistance && curDistance < maxDistance;
    }
    private static bool TestAngle(Vector3 angleA, Vector3 angleB, float angle)
    {
        return Vector3.Angle(angleA.normalized, angleB.normalized) < angle / 2;
    }
    #endregion

    #region Transform Extensions
    private static Vector3 pointOnGround;
    public static void StickToGround(this Transform transform, RaycastHit groundHit, float damping = 60)
    {
        if (groundHit.point == Vector3.zero)
        {
            return;
        }

        //Quaternion rotation = transform.rotation;
        //Vector3 position = transform.position;
        Matrix4x4 matrix = Matrix4x4.TRS(groundHit.point, transform.rotation, Vector3.one);
        pointOnGround = groundHit.normal * matrix.inverse.MultiplyPoint(transform.position).y;
        transform.position -= pointOnGround * damping * Time.deltaTime;
    }
    public static Vector3 DirectionTo(this Transform transform, Vector3 position)
    {
        return (position - transform.position).normalized;
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
    public static GroundState GetGroundState(this Transform transform)
    {
        int angleMin = 10;
        int angleMid = 45;
        int angleMax = 135;

        float angle = Vector3.Angle(transform.up, Vector3.up);

        if (angle > angleMin && angle < angleMid)
        {
            return GroundState.onSlope;
        }
        else if (angle > angleMid && angle < angleMax)
        {
            return GroundState.onWall;
        }
        else if (angle > angleMax)
        {
            return GroundState.onCeiling;
        }
        else
        {
            return GroundState.onGround;
        }
    }
    #endregion

    #region Rigidbody Extensions
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
    #endregion    
}