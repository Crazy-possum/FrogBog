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
        
        foreach(TransformSercher tsercher in _spawnZoneList) 
        {
            tsercher.OnSpawnAction += SpawnEnemy;
        }
    }

    private void OnDestroy()
    {
        foreach (TransformSercher tsercher in _spawnZoneList)
        {
            tsercher.OnSpawnAction -= SpawnEnemy;
        }
    }

    private void SpawnEnemy(Vector2 position)
    {
        GameObject.Instantiate(_enemyPrefab,position,Quaternion.identity,_rootTransform);
    }
}
