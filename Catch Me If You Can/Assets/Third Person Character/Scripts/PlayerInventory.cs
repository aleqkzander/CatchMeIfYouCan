using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerBuff _playerBuff;
    public List<ItemSlot> ItemSlots;

    public void AddItem(ScriptableItem item)
    {
        foreach (ItemSlot slot in ItemSlots)
        {
            if (slot.InventoryItem.Item == null)
            {
                slot.gameObject.SetActive(true);
                slot.InventoryItem.Item = item;
                slot.InventoryItem.Amount++;
                slot.UpdateUI();
                return;
            }
            else if (slot.InventoryItem.Item == item)
            {
                slot.InventoryItem.Amount++;
                slot.UpdateUI();
                return;
            }
        }
    }

    private void Update()
    {
        if (_playerBuff.IsOnCooldown()) return;

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            ItemSlot slot = ItemSlots[0];
            if (slot.InventoryItem == null) return;
            if (slot.InventoryItem.Amount == 0) return;

            slot.UseItem(_playerBuff);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            ItemSlot slot = ItemSlots[1];
            if (slot.InventoryItem == null) return;
            if (slot.InventoryItem.Amount == 0) return;

            slot.UseItem(_playerBuff);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            ItemSlot slot = ItemSlots[2];
            if (slot.InventoryItem == null) return;
            if (slot.InventoryItem.Amount == 0) return;

            slot.UseItem(_playerBuff);
        }
    }
}
