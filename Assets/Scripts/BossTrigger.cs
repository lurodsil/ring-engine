using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public Stage stage;

    public EggmanMobile eggmanMobile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.playerTag))
        {
            eggmanMobile.active = true;
            stage.StartBossBattle();
            gameObject.SetActive(false);
        }

    }
}
