using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MovementController
{
    [SerializeField] protected Transform bodyTransform;
    [SerializeField] protected Transform gunBarrelTransform;
    [SerializeField] protected Transform gunMuzzleTransform;

    protected override void MoveToDirection(Vector3 direction)
    {
        base.MoveToDirection(direction);
        bodyTransform.up = Vector3.Lerp(bodyTransform.up, direction, 0.02f);
    }

    protected override void MoveToPosition(Vector3 target)
    {
        base.MoveToPosition(target);
        bodyTransform.up = Vector3.Lerp(bodyTransform.up, target, 0.02f);
    }

    protected virtual void RotateGunBarrel(Vector3 direction)
    {
        gunBarrelTransform.up = Vector3.Lerp(gunBarrelTransform.up, direction, 0.1f);
    }

    protected virtual void Shoot()
    {
        CreateController.Instance.GetBullet(gunMuzzleTransform.position, gunBarrelTransform.localEulerAngles);
    }
}
