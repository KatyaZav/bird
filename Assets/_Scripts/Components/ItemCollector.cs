using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _inventoryPoint;

    private Inventory _inventory;

    public void Init()
    {
        _inventory = new Inventory(_inventoryPoint);
    }

    public void UseItem()
    {
        if (_inventory.IsEmpty)
        {
            Debug.LogError("No item to use");
            return;
        }

        ItemBase item = _inventory.GetItem();
        item.Use(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemBase item = collision.GetComponent<ItemBase>();

        if (item == null)
            return;

        if (_inventory.IsEmpty)
        {
            _inventory.SetItem(item);                           
            item.OnCollect();
        }
    }
}
