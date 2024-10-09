using UnityEngine;

public class HealItem : ItemBase
{
    [SerializeField] private int _healthCount;

    public override void Use(GameObject owner)
    {
        base.Use(owner);

        Health health = owner.GetComponent<Health>();

        health.Increse(_healthCount);
    }
}
