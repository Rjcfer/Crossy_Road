using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Data", menuName = "Terrain Data")]
public class TerrainData : ScriptableObject
{
    public List<GameObject> terrains;
    public int maxInSuccession;
    public bool isSpawn;
    public bool isStart;

}
