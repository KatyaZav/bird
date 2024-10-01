using UnityEngine;

public class Inventory
{
    private InventorySlot _slot;

    public Inventory(InventorySlot slot)
    {
        _slot = slot;
    }

    public bool IsEmpty => _slot.HasItem == false;

    public void AddItem(BaseItem item)
    {
        _slot.SetItem(item);
    }

    public bool TryUseItem(GameObject owner)
    {
        if (_slot.HasItem)
        {
            UseItem(owner);
            return true;
        }

        Debug.LogError("Объекта в инвенторе нет, нельзя использовать");
        return false;
    }

    public void UseItem(GameObject owner)
    {
        BaseItem item = _slot.GetItem();
        item.Use(owner);
    }
}
