using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatBaseController : MonoBehaviour
{
    [SerializeField] protected float originValue;
    [SerializeField] protected Transform currentStatValue;
    protected float currentValue;

    protected void ChangeStat(float changeAmount)
    {
        currentValue += changeAmount;
        UpdateUI();
    }

    public virtual void ResetStat()
    {
        UpdateUI();
    }


    protected abstract void UpdateUI();
}