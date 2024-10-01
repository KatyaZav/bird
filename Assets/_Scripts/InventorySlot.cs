using UnityEngine;

public class InventorySlot
{
    private BaseItem _item = null;

    public bool HasItem => _item != null;

    public void SetItem(BaseItem item)
    {
        if (item != null)
        {
            Debug.LogError("Слот уже заполнен");
            return;
        }

        _item = item;
    } 

    public BaseItem GetItem()
    {
        BaseItem currentItem = _item;
        _item = null;
        return currentItem; 
    }
}
