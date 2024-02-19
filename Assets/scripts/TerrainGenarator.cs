using System.Collections.Generic;
using UnityEngine;

public class TerrainGenarator : MonoBehaviour
{
    [SerializeField] private List<TerrainData> terrains = new List<TerrainData>();
    [SerializeField] private int maxTerrainCount;
    private Vector3 currentPos = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain();
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
        int wichTerrain = Random.Range(0, terrains.Count);
        int terrainInSuccession = Random.Range(1, terrains[wichTerrain].maxInSuccession);

        for (int i = 0; i < terrainInSuccession; i++)
        {
            GameObject terrain = Instantiate(terrains[wichTerrain].terrain, currentPos, Quaternion.identity);
            currentTerrains.Add(terrain);
            if (currentTerrains.Count > maxTerrainCount)
            {
                Destroy(currentTerrains[0]);
                currentTerrains.RemoveAt(0);
            }
            currentPos.x++;
        }

    }
}
