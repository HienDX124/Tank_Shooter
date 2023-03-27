using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MovementController, IHit
{
    [SerializeField] protected Transform bodyTransform;
    [SerializeField] protected Transform gunBarrelTransform;
    [SerializeField] protected Transform gunMuzzleTransform;
    [SerializeField] protected HPController hPController;

    protected virtual void OnEnable()
    {
        hPController.onZeroHP += Die;
    }

    protected virtual void OnDisable()
    {
        hPController.onZeroHP -= Die;
    }

    public virtual void OnHit(float damage)
    {
        hPController.TakeDamage(damage);
    }

    protected override void MoveToDirection(Vector3 direction)
    {
        base.MoveToDirection(direction);
        bodyTransform.up = Vector3.Lerp(bodyTransform.up, direction, 0.02f);
    }

    protected override void MoveToPosition(Vector3 target)
    {
        base.MoveToPosition(target);
        bodyTransform.up = Vector3.Lerp(bodyTransform.up, (transform.position - target), 0.02f);
    }

    protected virtual void RotateGunBarrel(Vector3 direction)
    {
        gunBarrelTransform.up = Vector3.Lerp(gunBarrelTransform.up, direction, 0.1f);
    }

    protected virtual void Shoot()
    {
        CreateController.Instance.GetBullet(gunMuzzleTransform.position, gunBarrelTransform.localEulerAngles);
    }

    protected virtual void Die()
    {
        //  TODO: Turn off object
        Destroy(gameObject);

        //  TODO: Play FX die
        CreateController.Instance.Explode(transform.position);
    }
}