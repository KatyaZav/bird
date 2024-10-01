using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private BaseItem _item;

    public bool HasItem => _item != null;

    public void SetItem(BaseItem item)
    {
        if (item != null)
        {
            Debug.LogError("���� ��� ��������");
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
