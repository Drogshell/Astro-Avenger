using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigs;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private bool isLooping = true;
    private WaveConfigSO _currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (var wave in waveConfigs)
            {
                _currentWave = wave;
                for (var i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(i), 
                        _currentWave.GetStartingWaypoint().position, 
                        Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }
}
