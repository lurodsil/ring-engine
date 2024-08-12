using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public Stage stage;

    public EggmanMobile eggmanMobile;

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
