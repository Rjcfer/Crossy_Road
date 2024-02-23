using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeperationTime;
    [SerializeField] private float maxSeperationTime;
    [SerializeField] private bool isRightSide;
    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    private IEnumerator SpawnVehicle()
    {

        for (int i = 1; i < 10; i++)
        {
            GameObject go = null;

            if (isRightSide)
            {
                go = Instantiate(objectToSpawn,
                new Vector3(spawnPos.position.x, spawnPos.position.y, 2 * i),
                Quaternion.identity);
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
            else
            {
                go = Instantiate(objectToSpawn,
                 new Vector3(spawnPos.position.x, spawnPos.position.y, -2 * i),
                 Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(minSeperationTime, maxSeperationTime));
        }

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeperationTime, maxSeperationTime));
            GameObject go = Instantiate(objectToSpawn, spawnPos.position, Quaternion.identity);
            if (isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }

        }
    }
}
