using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSouls : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] List<GameObject> soulsPoint;

    public void SpawnSoul()
    {
        Transform point = soulsPoint[Random.Range(0, soulsPoint.Count)].transform;
        Instantiate(spawnPrefab, point.position, Quaternion.identity);
    }
}
