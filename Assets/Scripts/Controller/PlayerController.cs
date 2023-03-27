using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TankController
{
    private Vector2 cachedVector2;
    [SerializeField] private ExpController expController;
    [SerializeField] private float testExpRequire;
    private bool isMovingRightMouseClickPos;
    private Vector2 rightMouseClickPosWorldSpace;

    protected override void OnEnable()
    {
        base.OnEnable();
        expController.onLevelUp += LevelUp;
        Observer.Instance.RegistListener(EventID.EnemyDie, HandleEventEnemyDie);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        expController.onLevelUp -= LevelUp;
        Observer.Instance.RemoveListenner(EventID.EnemyDie, HandleEventEnemyDie);
    }

    private void Start()
    {
        expController.ResetStat();
        expController.SetExpRequireNextLevel(testExpRequire);
    }

    private void Update()
    {
        //  TODO: Handle move and aim
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        cachedVector2.Set(h, v);

        if (cachedVector2 != Vector2.zero)
        {
            MoveToDirection(cachedVector2);
            isMovingRightMouseClickPos = false;
        }

        //  TODO: Handle rotate gun barrel
        RotateGunBarrel(GetGunRotateDirection(Input.mousePosition));

        //  TODO: Handle shoot
        if (Input.GetMouseButtonDown(0)) Shoot();

        if (Input.GetMouseButtonDown(1))
        {
            rightMouseClickPosWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMovingRightMouseClickPos = true;
        }
        MoveToRightMouseClickPos();
    }

    private void HandleEventEnemyDie(object param = null)
    {
        EnemyController enemyController = (EnemyController)param;
        if (enemyController == null)
        {
            Debug.LogWarning("There's no enemyController component");
            return;
        }

        IncreaseExp(enemyController.ResourceHolder.exp);
    }

    private Vector2 GetGunRotateDirection(Vector2 mouseScreenPos)
    {
        return Camera.main.ScreenToWorldPoint(mouseScreenPos) - gunBarrelTransform.position;
    }

    private void MoveToRightMouseClickPos()
    {
        if (!isMovingRightMouseClickPos) return;
        MoveToPosition(rightMouseClickPosWorldSpace);

        if ((Vector2)transform.position == rightMouseClickPosWorldSpace)
        {
            isMovingRightMouseClickPos = false;
        }
    }

    public void IncreaseExp(float exp)
    {
        expController.IncreaseExp(exp);
    }

    public void LevelUp()
    {
        Debug.Log("Level up");
    }
}