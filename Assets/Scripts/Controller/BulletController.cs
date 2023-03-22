using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MovementController
{
    [SerializeField] private int existFrameCount;

    void Update()
    {
        MoveToDirection(transform.up);
        existFrameCount--;
        if (existFrameCount <= 0) Destroy(gameObject);
    }
}
