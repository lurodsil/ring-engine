using UnityEngine;

public class PlayerMesh : MonoBehaviour
{
    public Player player;
    public float rotationDamping = 10;

    void Start()
    {
        transform.parent = null;
    }

    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, rotationDamping * Time.deltaTime);
    }
}
