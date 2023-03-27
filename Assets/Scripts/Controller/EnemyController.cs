using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    [field: SerializeField] public EnemyResourceHolder ResourceHolder { get; protected set; }
    public delegate void OnEnemyDie(EnemyResourceHolder resourceHolder);
    public OnEnemyDie onEnemyDie;

    private void Start()
    {
        hPController.ResetStat();
    }

    protected override void Die()
    {
        base.Die();
        if (onEnemyDie != null)
        {
            onEnemyDie(ResourceHolder);
        }

        Observer.Instance.PostEvent(EventID.EnemyDie, this);
    }
}

[System.Serializable]
public class EnemyResourceHolder
{
    public int coins;
    public float exp;
}