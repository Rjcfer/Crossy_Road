using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int distFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainData = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    private List<GameObject> currentTerrains = new List<GameObject>();
    [SerializeField] private int grassToSpawnAtStart = 4;
    [SerializeField] private GameObject spawnGrass;
    [HideInInspector] public Vector3 currentPos = new Vector3(0, 0, 0);
    private bool spawnGenerated = false;
    private bool pastWaterLeft = false;

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
        GameObject terrain = null;
        if ((currentPos.x - playerPos.x < distFromPlayer) || isStart)
        {
            if (!spawnGenerated)
            {
                for (int i = 0; i < grassToSpawnAtStart; i++)
                {
                    terrain = Instantiate(spawnGrass, currentPos, Quaternion.identity, terrainHolder);
                    terrain.transform.SetParent(terrainHolder);
                    currentTerrains.Add(terrain);
                    currentPos.x++;
                }
                spawnGenerated = true;
            }
            int wichTerrain = Random.Range(0, terrainData.Count);
            int terrainInSuccession = Random.Range(1, terrainData[wichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                TerrainData ter = terrainData[wichTerrain];
                ter.isStart = isStart;
                if (ter.name == "Water")
                {

                    terrain = Instantiate(ter.terrains[pastWaterLeft ? 0 : 1], currentPos, Quaternion.identity, terrainHolder);
                    pastWaterLeft = !pastWaterLeft;
                }
                else
                {
                    terrain = Instantiate(ter.terrains[Random.Range(0, terrainData[wichTerrain].terrains.Count)], currentPos, Quaternion.identity, terrainHolder);
                }
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
