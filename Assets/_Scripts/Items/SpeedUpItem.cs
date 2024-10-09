using UnityEngine;

public class SpeedUpItem : ItemBase
{
    [SerializeField] private float _coefficient;

    public override void Use(GameObject owner)
    {
        base.Use(owner);

        Jumper player = owner.GetComponent<Jumper>();     

        player.AddSpeed(_coefficient);
    }
}
