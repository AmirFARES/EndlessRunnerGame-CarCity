using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class plotSpawner : MonoBehaviour
{
    private int initAmount = 7;
    private float plotSize = 36;
    private float xPosLeft= -41;
    private float xPosRight= 41;
    private float lastZPos= -36;
    public List<GameObject> plots;
    public List<GameObject> spawnedPlots;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];
        float zPos = lastZPos + plotSize;
        spawnedPlots.Add((GameObject)Instantiate(plotLeft, new Vector3(xPosLeft, 0.025f, zPos), plotLeft.transform.rotation));
        spawnedPlots.Add((GameObject)Instantiate(plotRight, new Vector3(xPosRight, 0.025f, zPos), new Quaternion(0, 180, 0, 0)));
        lastZPos += plotSize;
    }
    public void DeletePlot()
    {
        if (spawnedPlots != null && spawnedPlots.Count > 16)
        {
            spawnedPlots = spawnedPlots.OrderBy(r => r.transform.position.z).ToList();
            GameObject tmpPlot = spawnedPlots[0];
            spawnedPlots.Remove(tmpPlot);
            Destroy(tmpPlot);

            GameObject tmpPlot2 = spawnedPlots[0];
            spawnedPlots.Remove(tmpPlot2);
            Destroy(tmpPlot2);
        }
        
    }
}
