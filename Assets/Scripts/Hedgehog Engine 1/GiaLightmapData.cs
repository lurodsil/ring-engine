using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hedgehog Engine 1/GIA Lightmap Data")]
public class GiaLightmapData : ScriptableObject
{
    public Texture2D[] lightmaps;
    public Texture2D[] directionalLightmaps;
    public List<GameObjectBinding> bindings = new List<GameObjectBinding>();

    [System.Serializable]
    public struct GameObjectBinding
    {
        public string gameObjectName;
        public int lightmapIndex;
        public Vector4 scaleOffset;
    }
}
