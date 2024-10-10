using UnityEngine;

public class ShootItem : ItemBase
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _coefficient;

    public override bool CanPick(GameObject owner)
    {
        return owner.GetComponent<ShootAbility>() != null;
    }

    public override void Use(GameObject owner)
    {
        base.Use(owner);

        ShootAbility shootPoint = owner.GetComponent<ShootAbility>();

        if (shootPoint == null)
        {
            Debug.LogError("Can't find player script");
            return;
        }

        Bullet bullet = Instantiate(_bullet, shootPoint.ShootPoint.position, Quaternion.identity, null);
        bullet.Launch(_coefficient * shootPoint.ShootPoint.forward);
    }
}
