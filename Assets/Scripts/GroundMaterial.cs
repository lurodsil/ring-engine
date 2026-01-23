using UnityEngine;

[System.Serializable]
public class GroundMaterial
{
    public string Name;
    public PhysicsMaterial physicMaterial;
    public AudioClip[] footstep;
    public AudioClip land;
    public AudioClip brake;
    public Texture2D smoke;
}
