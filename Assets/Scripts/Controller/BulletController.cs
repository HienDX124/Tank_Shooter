using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MovementController
{
    [SerializeField] private int existFrameCount;
    [SerializeField] protected float damage;

    void Update()
    {
        MoveToDirection(transform.up);
        existFrameCount--;
        if (existFrameCount <= 0) DisableBullet();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.2f);
        if (hit.transform != null)
        {
            hit.transform.GetComponent<IHit>().OnHit(damage);
            DisableBullet();
            return;
        }
    }

    protected void DisableBullet()
    {
        CreateController.Instance.Explode(transform.position);
        Destroy(gameObject);
    }

}

public interface IHit
{
    public void OnHit(float damage);
}