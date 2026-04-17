using UnityEngine;

namespace RingEngine
{
    public class InstantiatePrefabOnChildren : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject prefab;

        [Header("Options")]
        [SerializeField] private bool randomYRotation = false;
        [SerializeField] private bool alignToNormal = false;

        [Header("Normal Settings")]
        [SerializeField] private float normalRayDistance = 5f;
        [SerializeField] private LayerMask normalLayerMask = -1;


        [ContextMenu("Instantiate Prefabs")]
        private void InstantiateOnChildren()
        {
            foreach (Transform child in transform)
            {
                Vector3 position = child.position;
                Quaternion rotation = child.rotation;

                if (alignToNormal)
                {
                    if (Physics.Raycast(position + Vector3.up, Vector3.down, out RaycastHit hit, normalRayDistance, normalLayerMask))
                    {
                        rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    }
                }

                if (randomYRotation)
                {
                    float randomY = Random.Range(0f, 360f);
                    rotation *= Quaternion.Euler(0, randomY, 0);
                }

                GameObject instance = Instantiate(prefab, position, rotation);

                instance.transform.parent = child;
            }
        }
    }
}