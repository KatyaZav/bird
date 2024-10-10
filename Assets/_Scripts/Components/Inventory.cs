using UnityEngine;

public class Inventory
{
    private ItemBase _item = null;
    private Transform _itemPlace;

    public bool IsEmpty => _item == null;
    
    public Inventory(Transform itemPlace)
    {
        _itemPlace = itemPlace;
    }

    public void SetItem(ItemBase item)
    {
        if (IsEmpty == false)
        {
            Debug.LogError("Слот уже заполнен");
            return;
        }

        _item = item;

        _item.transform.parent = _itemPlace;
        _item.transform.localPosition = Vector3.zero;
    }

    public ItemBase GetItem()
    {
        _item.transform.parent = null;

        ItemBase currentItem = _item;
        _item = null;
        return currentItem;
    }
}
