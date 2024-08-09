using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSmoother : MonoBehaviour
{
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        var heights = terrain.terrainData.GetHeights(0, 0, 4097, 4097);

        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 100; j++)
                heights[(int)transform.position.z + i, (int)transform.position.x + j] = 0;

        terrain.terrainData.SetHeights(0, 0, heights);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
