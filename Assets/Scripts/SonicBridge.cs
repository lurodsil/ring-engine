using UnityEngine;
using System.Collections.Generic;

public class SonicBridge : MonoBehaviour
{
    [Header("Bridge Generation")]
    public Transform startPoint;
    public Transform endPoint;
    public GameObject plankPrefab;
    public float plankLength = 1f;

    [Header("Player")]
    public Transform player;

    [Header("Bridge Physics")]
    public float maxSag = 1.5f;
    public float influence = 4f;
    public float returnSpeed = 6f;

    [Header("Bridge Shape")]
    public int edgeInfluence = 5; // quantos planks fazem o fade nas pontas

    List<Transform> planks = new List<Transform>();
    List<Vector3> originalPositions = new List<Vector3>();

    public float bridgeWidth = 2f;

    private void Start()
    {
        GenerateBridge();
    }

    void Update()
    {
        UpdateBridge();
    }

    [ContextMenu("Generate Bridge")]
    void GenerateBridge()
    {
        ClearBridge();

        Vector3 dir = (endPoint.position - startPoint.position);
        float distance = dir.magnitude;
        dir.Normalize();

        int count = Mathf.RoundToInt(distance / plankLength);

        for (int i = 0; i <= count; i++)
        {
            Vector3 pos = startPoint.position + dir * plankLength * i;

            GameObject plank = Instantiate(
                plankPrefab,
                pos,
                Quaternion.LookRotation(dir),
                transform
            );

            planks.Add(plank.transform);
            originalPositions.Add(plank.transform.localPosition);
        }
    }

    void UpdateBridge()
    {
        if (planks.Count == 0) return;

        bool playerOnBridge = IsPlayerOnBridge();

        if (!playerOnBridge)
        {
            ReturnBridge();
            return;
        }

        int closestIndex = GetClosestPlank();

        for (int i = 0; i < planks.Count; i++)
        {
            float dist = Mathf.Abs(i - closestIndex);

            float weight = Mathf.Clamp01(1 - (dist / influence));

            float centerFactor = GetCenterInfluence(i);

            float sag = weight * maxSag * centerFactor;

            Vector3 target = originalPositions[i] - transform.up * sag;

            planks[i].localPosition = Vector3.Lerp(
                planks[i].localPosition,
                target,
                Time.deltaTime * returnSpeed
            );
        }

        UpdatePlankRotations();
    }

    void UpdatePlankRotations()
    {
        for (int i = 0; i < planks.Count; i++)
        {
            int prev = Mathf.Max(i - 1, 0);
            int next = Mathf.Min(i + 1, planks.Count - 1);

            Vector3 p0 = planks[prev].position;
            Vector3 p1 = planks[next].position;

            Vector3 forward = (p1 - p0).normalized;

            Quaternion targetRot = Quaternion.LookRotation(forward, transform.up);

            planks[i].rotation = Quaternion.Slerp(
                planks[i].rotation,
                targetRot,
                Time.deltaTime * returnSpeed
            );
        }
    }

    void ReturnBridge()
    {
        for (int i = 0; i < planks.Count; i++)
        {
            planks[i].localPosition = Vector3.Lerp(
                planks[i].localPosition,
                originalPositions[i],
                Time.deltaTime * returnSpeed
            );
        }
    }

    float GetCenterInfluence(int index)
    {
        int last = planks.Count - 1;

        if (index < edgeInfluence)
        {
            return (float)index / edgeInfluence;
        }

        if (index > last - edgeInfluence)
        {
            return (float)(last - index) / edgeInfluence;
        }

        return 1f;
    }

    bool IsPlayerOnBridge()
    {
        Vector3 bridge = endPoint.position - startPoint.position;
        float length = bridge.magnitude;

        Vector3 dir = bridge.normalized;

        Vector3 toPlayer = player.position - startPoint.position;

        float along = Vector3.Dot(toPlayer, dir);

        if (along < 0 || along > length)
            return false;

        Vector3 closestPoint = startPoint.position + dir * along;

        float distance = Vector3.Distance(player.position, closestPoint);

        return distance <= bridgeWidth;
    }

    int GetClosestPlank()
    {
        float best = float.MaxValue;
        int index = 0;

        for (int i = 0; i < planks.Count; i++)
        {
            float d = Vector3.Distance(player.position, planks[i].position);

            if (d < best)
            {
                best = d;
                index = i;
            }
        }

        return index;
    }

    void ClearBridge()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            DestroyImmediate(transform.GetChild(i).gameObject);

        planks.Clear();
        originalPositions.Clear();
    }
}