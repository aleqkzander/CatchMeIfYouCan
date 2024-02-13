using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemSlot : MonoBehaviour
{
    public InventoryItem InventoryItem;
    public Image Icon;
    public TMP_Text Amount;

    /// <summary>
    /// Add item to the inventory. Function is making required checks.
    /// </summary>
    /// <param name="item"></param>
    public void UpdateUI()
    {
        if (Icon.sprite == null)
        {
            Icon.sprite = InventoryItem.Item.Sprite;
        }

        Amount.text = InventoryItem.Amount.ToString("00");
    }

    /// <summary>
    /// Use item. Function is making required checks.
    /// </summary>
    /// <param name="playerBuff"></param>
    public void UseItem(PlayerBuff playerBuff)
    {
        InventoryItem.Item.ActivateItem(playerBuff);
        InventoryItem.Amount--;
        UpdateUI();

        if (InventoryItem.Amount == 0)
        {
            InventoryItem.Item = null;
            Icon.sprite = null;
            gameObject.SetActive(false);
        }
    }
}
