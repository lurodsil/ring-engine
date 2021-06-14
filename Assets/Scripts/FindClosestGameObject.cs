using UnityEngine;

public static class ExtensionMethods
{
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
}
