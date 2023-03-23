using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : StatBaseController
{
    public float currentExp => currentValue;
    private float expRequireNextLevel;
    public delegate void OnLevelUp();
    public OnLevelUp onLevelUp;

    public void SetExpRequireNextLevel(float nextLevelExp)
    {
        expRequireNextLevel = nextLevelExp;
    }

    public override void ResetStat()
    {
        currentValue = 0f;
        base.ResetStat();
    }

    public void IncreaseExp(float inceraseValue)
    {
        base.ChangeStat(inceraseValue);
        if (currentExp >= expRequireNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        ResetStat();
        UpdateUI();
        if (onLevelUp != null) onLevelUp();
    }

    protected override void UpdateUI()
    {
        Vector3 newScale = Vector3.zero;
        if (currentValue != 0)
        {
            newScale = new Vector3((currentValue / expRequireNextLevel), currentStatValue.localScale.y, currentStatValue.localScale.z);
        }
        else
        {
            newScale = new Vector3(0f, currentStatValue.localScale.y, currentStatValue.localScale.z);
        }
        currentStatValue.localScale = newScale;
    }
}