using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform spawnPrefab;

    [SerializeField]
    float lifeTimeout;

    [SerializeField]
    float intervalTimeout;

    [SerializeField]
    Transform[] spawingPoints;

    float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= intervalTimeout)
        {
            Transform spawningPoint = spawingPoints[Random.Range(0, spawingPoints.Length)];
            Transform spawnObject = Instantiate(spawnPrefab, spawningPoint.position, Quaternion.identity);

            Destroy(spawnObject.gameObject, lifeTimeout);
            _currentTime = 0.0F;
        }
    }
}
