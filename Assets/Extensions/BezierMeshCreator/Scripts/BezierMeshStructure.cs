using UnityEngine;

[System.Serializable]
public class BezierMeshStructure
{
    public string name;
    public GameObject part;
    public GameObject cap;
    public GameObject wall;
    public float scale;
    public float colliderScale;
    public ColliderType colliderType;

    public BezierMeshStructure() {}

    public BezierMeshStructure(string name, GameObject part, GameObject cap, GameObject wall, float scale, ColliderType colliderType)
    {
        this.name = name;
        this.part = part;
        this.cap = cap;
        this.wall = wall;
        this.scale = scale;
        this.colliderType = colliderType;
    }
}
