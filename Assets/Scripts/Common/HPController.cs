using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : StatBaseController
{
    public float currentHP => currentValue;
    public delegate void OnZeroHP();
    public OnZeroHP onZeroHP;

    public void TakeDamage(float damage)
    {
        ChangeStat(-damage);
        Debug.Log($"{this.name} take damage: {damage}, current hp: {currentHP}");
        if (currentHP <= 0) ZeroHP();
    }

    public override void ResetStat()
    {
        currentValue = originValue;
        base.ResetStat();
    }

    protected void ZeroHP()
    {
        if (onZeroHP != null) onZeroHP();
    }

    protected override void UpdateUI()
    {
        Vector3 newScale = Vector3.zero;
        if (currentValue != 0)
        {
            newScale = new Vector3((currentValue / originValue), currentStatValue.localScale.y, currentStatValue.localScale.z);
        }
        else
        {
            newScale = new Vector3(0f, currentStatValue.localScale.y, currentStatValue.localScale.z);
        }
        currentStatValue.localScale = newScale;
    }
}