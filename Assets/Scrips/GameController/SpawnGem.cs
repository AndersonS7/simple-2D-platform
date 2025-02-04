using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGem : MonoBehaviour
{
    [SerializeField] GameObject gem;
    [SerializeField] List<GameObject> spawnPoint;

    public void SpawnNewGem()
    {
        Transform point = spawnPoint[Random.Range(0, spawnPoint.Count)].transform;
        Instantiate(gem, point.position, Quaternion.identity);
    }
}
