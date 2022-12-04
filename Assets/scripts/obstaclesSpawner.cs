using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class obstaclesSpawner : MonoBehaviour
{
    private int initAmount = 7;
    private float plotSize = 36;
    private float xPos = 0;
    private float lastZPos = 0;
    public List<GameObject> obstaclesPlots;
    public List<GameObject> spawnedObstaclesPlots;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnObstaclesPlot();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObstaclesPlot()
    {
        GameObject plot = obstaclesPlots[Random.Range(0, obstaclesPlots.Count)];
        float zPos = lastZPos + plotSize;
        spawnedObstaclesPlots.Add((GameObject)Instantiate(plot, new Vector3(xPos, 0.025f, zPos), plot.transform.rotation));
        lastZPos += plotSize;
    }
    public void DeleteObstaclesPlot()
    {
        if (spawnedObstaclesPlots != null && spawnedObstaclesPlots.Count > 8)
        {
            spawnedObstaclesPlots = spawnedObstaclesPlots.OrderBy(r => r.transform.position.z).ToList();
            GameObject tmpObstaclesPlot = spawnedObstaclesPlots[0];
            spawnedObstaclesPlots.Remove(tmpObstaclesPlot);
            Destroy(tmpObstaclesPlot);

            GameObject tmpObstaclesPlot2 = spawnedObstaclesPlots[0];
            spawnedObstaclesPlots.Remove(tmpObstaclesPlot2);
            Destroy(tmpObstaclesPlot2);
        }

    }
}
