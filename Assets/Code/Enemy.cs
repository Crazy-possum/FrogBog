using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;

    private void Start()
    {
        StageController.Instance.OnChangeStage += ChangeEnemyState;
    }

    private void OnDestroy()
    {
        StageController.Instance.OnChangeStage -= ChangeEnemyState;
    }

    private void ChangeEnemyState(int stageInt)
    {
        if (stageInt == 2)
        {
            _enemySprite.enabled = false;
        }
        else if (stageInt == 3)
        {
            _enemySprite.enabled = true;
        }
    }
}

