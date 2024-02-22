using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int distFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainData = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    private List<GameObject> currentTerrains = new List<GameObject>();
    [SerializeField] private int grassToSpawnAtStart = 2;

    [HideInInspector] public Vector3 currentPos = new Vector3(0, 0, 0);

    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));
        }
        maxTerrainCount = currentTerrains.Count;

    }


    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if ((currentPos.x - playerPos.x < distFromPlayer) || isStart)
        {
            int wichTerrain = -1;
            int terrainInSuccession = 1;
            if (grassToSpawnAtStart > 0)
            {
                wichTerrain = terrainData.FindIndex(t => t.isGrass);
                terrainInSuccession = Random.Range(1, terrainData[wichTerrain].maxInSuccession);
                grassToSpawnAtStart--;

            }

            if (wichTerrain <= 0 || grassToSpawnAtStart <= 0)
            {
                wichTerrain = Random.Range(0, terrainData.Count);
                terrainInSuccession = Random.Range(1, terrainData[wichTerrain].maxInSuccession);
            }


            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainData[wichTerrain].terrains[Random.Range(0, terrainData[wichTerrain].terrains.Count)], currentPos, Quaternion.identity, terrainHolder); ;
                terrain.transform.SetParent(terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }

                currentPos.x++;
            }
        }
    }
}
