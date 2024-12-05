using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyAlive;
    [SerializeField] private GameObject _enemyKilled;
    private bool _isDead;

    public bool IsDead { get => _isDead; set => _isDead = value; }

    private void Start()
    {
        StageController.Instance.OnChangeStage += ChangeEnemyState;
    }

    private void OnDestroy()
    {
        StageController.Instance.OnChangeStage -= ChangeEnemyState;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsDead = true;
        }
    }

    private void ChangeEnemyState(int stageInt)
    {
        if (stageInt == 2)
        {
            _enemyAlive.SetActive(false);
        }
        else if (stageInt == 3)
        {
            if (IsDead)
            {
                _enemyKilled.SetActive(true);
            }
            else
            {
                _enemyAlive.SetActive(true);
            }
        }
    }
}

