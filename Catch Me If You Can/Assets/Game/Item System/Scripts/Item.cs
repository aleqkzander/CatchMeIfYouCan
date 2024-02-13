using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ScriptableItem ScriptableItem;
    private bool _notPickable;

    private void OnTriggerEnter(Collider other)
    {
        if (_notPickable) return;
        if (!other.CompareTag("Player")) return;
        if (ScriptableItem == null) return;
        if (other.GetComponent<PlayerBuff>().IsOnCooldown()) return;

        AudioSource.PlayClipAtPoint(ScriptableItem.Clip, gameObject.transform.position);
        other.GetComponentInChildren<PlayerInventory>().AddItem(ScriptableItem);
        StartCoroutine(StartItemGrow(ScriptableItem.RespawnTime));
    }

    private IEnumerator StartItemGrow(float time)
    {
        _notPickable = true;
        GetComponent<Animation>().Play("ItemShrink");
        yield return new WaitForSecondsRealtime(time);
        GetComponent<Animation>().Play("ItemGrow");
        _notPickable = false;
    }
}
