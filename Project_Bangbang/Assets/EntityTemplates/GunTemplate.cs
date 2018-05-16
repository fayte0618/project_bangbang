using UnityEngine;
using System.Collections;
using Entitas;

public class GunTemplate : UnityEntityTemplate
{
    [SerializeField]
    private string _bulletEntityID;
    [SerializeField]
    private float _fireRate;

    protected override IEntity InitializeEntity (Contexts contexts)
    {
        var ety = contexts.game.CreateEntity();
        ety.AddGun(_fireRate);
        ety.AddCooldown(0f);
        ety.AddBullet(_bulletEntityID);

        return ety;
    }
}
