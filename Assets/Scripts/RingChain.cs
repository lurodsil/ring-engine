using UnityEngine;

public class RingChain : MonoBehaviour
{

    public int xSize = 2;
    public int ySize = 0;
    public int zSize = 2;

    public float spacing = 1;
    public float upOffset = 0.5f;

    public GameObject ringPrefab;

    public bool isLightSpeedDash;

    void Start()
    {

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    Vector3 position = new Vector3(transform.position.x + x, transform.position.y + y + upOffset, transform.position.z + z);

                    Ring ring = Instantiate(ringPrefab, position, Quaternion.identity, transform).GetComponent<Ring>();

                    ring.IsLightSpeedDashTarget = isLightSpeedDash;
                }
            }
        }
    }
}
