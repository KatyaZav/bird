using UnityEngine;

public class InventorySlot
{
    private ItemBase _item = null;

    public bool HasItem => _item != null;

    public void SetItem(ItemBase item)
    {
        if (_item != null)
        {
            Debug.LogError("Слот уже заполнен");
            return;
        }

        _item = item;
    } 

    public ItemBase GetItem()
    {
        ItemBase currentItem = _item;
        _item = null;
        return currentItem; 
    }
}
