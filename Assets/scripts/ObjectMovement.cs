using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speedMax;
    [SerializeField] private float speedMin;
    public bool isLog;

    void Update()
    {
        transform.Translate(Vector3.forward * UnityEngine.Random.Range(speedMin, speedMax) * Time.deltaTime);
    }
}
