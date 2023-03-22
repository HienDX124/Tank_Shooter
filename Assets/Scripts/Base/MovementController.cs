using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    protected virtual void MoveToDirection(Vector3 direction)
    {
        transform.position += direction.normalized * Time.deltaTime * moveSpeed;
    }

    protected virtual void MoveToPosition(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
    }

}
