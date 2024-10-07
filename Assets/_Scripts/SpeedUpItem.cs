using UnityEngine;

public class SpeedUpItem : ItemBase
{
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

        player.AddSpeed(_coefficient);
    }
}
