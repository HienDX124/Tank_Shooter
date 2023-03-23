using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private EnemyController[] enemyControllers;
    private PlayerController playerController;

    private void Start()
    {
        enemyControllers = FindObjectsOfType<EnemyController>();
        foreach (var e in enemyControllers)
        {
            e.onEnemyDie += HandleEnemyDie;
        }
        playerController = FindObjectOfType<PlayerController>();
    }

    private void HandleEnemyDie(EnemyResourceHolder resourceHolder)
    {
        playerController.IncreaseExp(resourceHolder.exp);
    }
}
