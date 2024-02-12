using UnityEngine;

public class Item : MonoBehaviour
{
    public ScriptableItem ScriptableItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (ScriptableItem == null) return;
        if (other.GetComponent<PlayerBuff>().IsOnCooldown()) return;

        AudioSource.PlayClipAtPoint(ScriptableItem.Clip, gameObject.transform.position);

        other.GetComponentInChildren<PlayerInventory>().AddItem(ScriptableItem);
    }
}
