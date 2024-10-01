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

    public bool TryUseItem()
    {
        if (_slot.HasItem)
        {
            UseItem();
            return true;
        }

        Debug.LogError("Объекта в инвенторе нет, нельзя использовать");
        return false;
    }

    public void UseItem()
    {
        BaseItem item = _slot.GetItem();
        item.Use();
    }
}
