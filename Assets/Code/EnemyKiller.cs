using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private static EnemyKiller _instance;
    private List<Enemy> _enemyList;

    public static EnemyKiller Instance { get => _instance;}

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _enemyList = new List<Enemy>();
        StageController.Instance.OnChangeStage += CheckDeadEnemies;
    }

    private void OnDestroy()
    {
        StageController.Instance.OnChangeStage -= CheckDeadEnemies;
    }

    public void AddEnemy (Enemy enemy)
    {
        _enemyList.Add(enemy);
    }

    private void CheckDeadEnemies(int stageIndex)
    {
        if (stageIndex == 4)
        {
            bool isAllEnemiesDead = true;
            foreach (Enemy enemy in _enemyList)
            {
                if (!enemy.IsDead)
                {
                    isAllEnemiesDead = false;
                }
            }

            if(isAllEnemiesDead)
            {
                EndGameController.Instance.WinGameAction();
            }
            else
            {
                EndGameController.Instance.LoseGameAction();
            }
        }
    }
}
