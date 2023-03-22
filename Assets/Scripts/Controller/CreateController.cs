using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : SingletonMonoBehaviour<CreateController>
{
    [SerializeField] private BulletController bulletPrefab;

    public BulletController GetBullet(Vector3 position, Vector3 flyDirection)
    {
        BulletController bullet = Instantiate<BulletController>(bulletPrefab);
        bullet.transform.position = position;
        bullet.transform.localEulerAngles = flyDirection;
        return bullet;
    }
}
