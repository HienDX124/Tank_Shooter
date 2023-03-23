using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : SingletonMonoBehaviour<CreateController>
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private ExplosionController explosionPrefab;

    public BulletController GetBullet(Vector3 position, Vector3 flyDirection)
    {
        BulletController bullet = Instantiate<BulletController>(bulletPrefab);
        bullet.transform.position = position;
        bullet.transform.localEulerAngles = flyDirection;
        return bullet;
    }

    public void Explode(Vector3 pos)
    {
        Instantiate(explosionPrefab, pos, explosionPrefab.transform.rotation);
    }
}
