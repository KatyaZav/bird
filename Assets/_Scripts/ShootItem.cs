using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : ItemBase
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _coefficient;

    public override void Use(GameObject owner)
    {
        base.Use(owner);

        Player player = owner.GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Can't find player script");
            return;
        }

        float x = player.PlayerJumper.Velocity.x;

        Bullet bullet = Instantiate(_bullet, owner.transform.position, Quaternion.identity, null);
        bullet.Launch(_coefficient * x);
    }
}
