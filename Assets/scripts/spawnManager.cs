using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    roadSpawner roadSpawner;
    plotSpawner plotSpawner;
    obstaclesSpawner obstaclesSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<roadSpawner>();
        plotSpawner = GetComponent<plotSpawner>();
        obstaclesSpawner = GetComponent<obstaclesSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
        plotSpawner.SpawnPlot();
        plotSpawner.DeletePlot();
        obstaclesSpawner.SpawnObstaclesPlot();
        obstaclesSpawner.DeleteObstaclesPlot();
    }
}
