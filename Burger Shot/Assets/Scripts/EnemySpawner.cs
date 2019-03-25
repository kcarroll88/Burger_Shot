﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 1;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
    }
}
