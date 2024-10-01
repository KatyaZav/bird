using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : BaseItem
{
    [SerializeField] private int _coefficient;

    public override void Use(GameObject owner)
    {
        base.Use(owner);

        Player player = owner.GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Can't find player script");
            return;
        }

        player.AddHealth(_coefficient);
    }
}
