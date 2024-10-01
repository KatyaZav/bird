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
        BaseItem item = collision.GetComponent<BaseItem>();

        if (item == null)
            return;

        if (_inventory.IsEmpty)
        {
            SetToPoint(item, _inventoryPoint);

            _inventory.AddItem(item);                           
            item.Get();
        }
    }

    private void SetToPoint(BaseItem item, Transform point)
    {
        item.transform.parent = point;
        item.transform.localPosition = Vector3.zero;
    }
}
