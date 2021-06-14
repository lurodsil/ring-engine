using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TubeTrailRenderer : MonoBehaviour
{

    public bool emit = true;
    public ShadowCastingMode castShadows = ShadowCastingMode.Off;
    public bool receiveShadows = false;
    public Material material;
    public float radius = 0.5f;
    public int divisions = 18;
    public int maxSegments = 30;
    public float minVertexDistance = 0.2f;

    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();
    private Color[] vertexColors;
    private Mesh mesh;
    private int segments;
    private Vector3 lastVertexSegmentPosition;
    private float lastStateTime;

    private void Awake()
    {
        GameObject meshHolder = new GameObject("Tube Trail");
        meshHolder.AddComponent<MeshFilter>().sharedMesh = mesh = new Mesh();
        MeshRenderer meshRenderer = meshHolder.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        meshRenderer.shadowCastingMode = castShadows;
        meshRenderer.receiveShadows = receiveShadows;
        meshHolder.hideFlags = HideFlags.HideInHierarchy;
        mesh.name = "Procedural Tube";
    }

    void Start()
    {
        ClearTrail();
    }

    void Update()
    {
        if (emit)
        {
            lastStateTime = Time.time;
            if (vertices.Count == 0)
            {
                CreateFirstVertexSegment();
            }

            if (Vector3.Distance(transform.position, lastVertexSegmentPosition) > minVertexDistance)
            {
                CreateVertexSegment();
            }

            for (int i = 0; i < divisions; i++)
            {
                vertices[vertices.Count - divisions + i] = transform.position + Vector3.RotateTowards(transform.up * radius, -transform.right * radius, -i * (1 / (float)divisions) * (2 * Mathf.PI), 0);
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.colors = vertexColors;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            ;
        }
        else if (vertices.Count > 0 && Time.time > lastStateTime + 0.2f)
        {
            ClearTrail();
        }
    }

    void CreateFirstVertexSegment()
    {
        for (int i = 0; i < divisions; i++)
        {
            vertices.Add(transform.position + Vector3.RotateTowards(transform.up * radius, -transform.right * radius, -i * (1 / (float)divisions) * (2 * Mathf.PI), 0));
        }

        for (int i = 0; i < divisions; i++)
        {
            vertices.Add(transform.position + Vector3.RotateTowards(transform.up * radius, -transform.right * radius, -i * (1 / (float)divisions) * (2 * Mathf.PI), 0));
        }
        segments++;
        segments++;
        CalculateFirstTriangles();
        CalculateVertexColors();
        lastVertexSegmentPosition = transform.position;
    }

    void CreateVertexSegment()
    {
        for (int i = 0; i < divisions; i++)
        {
            vertices.Add(transform.position + Vector3.RotateTowards(transform.up * radius, -transform.right * radius, -i * (1 / (float)divisions) * (2 * Mathf.PI), 0));
        }
        segments++;
        if (segments > maxSegments)
        {
            RemoveSegment();
        }
        CalculateTriangles();
        CalculateVertexColors();
        lastVertexSegmentPosition = transform.position;
    }

    void CalculateFirstTriangles()
    {
        for (int i = 0; i < divisions; i++)
        {
            if (i < divisions - 1)
            {
                triangles.Add(i);
                triangles.Add(i + divisions);
                triangles.Add(i + 1);
                triangles.Add(i + 1);
                triangles.Add(i + divisions);
                triangles.Add(i + divisions + 1);
            }
            else
            {
                triangles.Add(i);
                triangles.Add(i + divisions);
                triangles.Add(0);
                triangles.Add(0);
                triangles.Add(i + divisions);
                triangles.Add(i + 1);
            }
        }
    }

    void CalculateTriangles()
    {
        int count = triangles.Count;
        for (int i = 0; i < divisions * 6; i++)
        {
            triangles.Add(triangles[count - (divisions * 6) + i] + divisions);
        }
    }

    void CalculateVertexColors()
    {
        vertexColors = new Color[vertices.Count];

        for (int i = 0; i < vertices.Count; i++)
        {
            vertexColors[i] = Color.white;
        }

        for (int i = 0; i < divisions; i++)
        {
            vertexColors[i].a = 0;

            if (vertices.Count > divisions * 2)
            {
                vertexColors[divisions + i] = new Color(1, 1, 1, 0.25f);
            }
            if (vertices.Count > divisions * 3)
            {
                vertexColors[divisions * 2 + i] = new Color(1, 1, 1, 0.5f);
            }
            if (vertices.Count > divisions * 4)
            {
                vertexColors[divisions * 3 + i] = new Color(1, 1, 1, 0.75f);
            }

            vertexColors[vertices.Count - divisions + i].a = 0;
        }
    }

    void RemoveSegment()
    {
        for (int i = 0; i < divisions; i++)
        {
            vertices.RemoveAt(0);
        }

        for (int i = 0; i < divisions * 6; i++)
        {
            triangles.RemoveAt(0);
        }

        int count = triangles.Count;

        for (int i = 0; i < count; i++)
        {
            triangles[i] -= divisions;
        }
        segments--;
    }



    void ClearTrail()
    {
        vertices.Clear();
        triangles.Clear();
        vertexColors = new Color[0];
        mesh.Clear();
        segments = 0;
    }

    void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.white;
        foreach (Vector3 v in vertices)
        {
            Gizmos.DrawWireSphere(v, 0.01f);
        }
    }
}
