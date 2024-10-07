using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Transform _inventoryPoint;

    private Inventory _inventory;

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemBase item = collision.GetComponent<ItemBase>();

        if (item == null)
            return;

        if (_inventory.IsEmpty)
        {
            SetToPoint(item, _inventoryPoint);

            _inventory.AddItem(item);                           
            item.OnCollect();
        }
    }

    private void SetToPoint(ItemBase item, Transform point)
    {
        item.transform.parent = point;
        item.transform.localPosition = Vector3.zero;
    }
}
