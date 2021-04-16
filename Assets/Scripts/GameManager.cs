using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefabs;

    private float spawnLimitXLeft = -10;
    private float spawnLimitXRight = 10;

    private float startDelay = 1.0f;
    private float spawnInterval;



    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(2.0f, 5.0f);
        InvokeRepeating("SpawnRandomTarget", startDelay, spawnInterval);
    }

    void SpawnRandomTarget() {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), 0.3f, -15.0f);
        Instantiate(targetPrefabs, spawnPos, targetPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
