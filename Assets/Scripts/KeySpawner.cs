using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Key key;
    public Transform[] keySpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        int randomPoint = Random.Range(0, keySpawnPoints.Length);
        Instantiate(key, keySpawnPoints[randomPoint].position, Quaternion.identity);
    }
}
