using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<TransformSercher> _spawnZoneList;
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private GameObject _enemyPrefab;

    void Start()
    {
        StageController.Instance.OnChangeStage += ChangeStage;
        ChangeStage(1);
    }

    private void ChangeStage(int stageIndex)
    {
        if (stageIndex == 1)
        {
            foreach (TransformSercher tsercher in _spawnZoneList)
            {
                tsercher.OnSpawnAction += SpawnEnemy;
            }
        }
        else if (stageIndex == 2)
        {
            foreach (TransformSercher tsercher in _spawnZoneList)
            {
                tsercher.OnSpawnAction -= SpawnEnemy;
            }
        }
    }

    private void SpawnEnemy(Vector2 position)
    {
        GameObject gObject = 
        GameObject.Instantiate(_enemyPrefab,position,Quaternion.identity,_rootTransform);
        Enemy enemy =
        gObject.GetComponent<Enemy>();

        EnemyKiller.Instance.AddEnemy(enemy);
    }
}
