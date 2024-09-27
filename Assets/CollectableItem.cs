using System;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Action<CollectableItem> Collected;

    private void OnCollisionEnter(Collision collision)
    {
        MovementController player = collision.gameObject.GetComponent<MovementController>();

        if (player != null)
        {
            Collect();
        }
    }

    private void Collect()
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }
}
