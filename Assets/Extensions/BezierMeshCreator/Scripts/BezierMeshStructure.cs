using UnityEngine;

[System.Serializable]
public class BezierMeshStructure
{
    public string name;
    public GameObject part;
    public GameObject cap;
    public float scale;
    public float colliderScale;
    public ColliderType colliderType;

    public BezierMeshStructure() {}

    public BezierMeshStructure(string name, GameObject part, GameObject cap, float scale, ColliderType colliderType)
    {
        this.name = name;
        this.part = part;
        this.cap = cap;
        this.scale = scale;
        this.colliderType = colliderType;
    }
}
