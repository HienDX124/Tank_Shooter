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
        playerController = FindObjectOfType<PlayerController>();
    }
}