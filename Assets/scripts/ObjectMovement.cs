using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speedMax;
    [SerializeField] private float speedMin;
    public bool isLog;

    void Update()
    {
        if (transform.position.z > 28 || transform.position.z < -28)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * UnityEngine.Random.Range(speedMin, speedMax) * Time.deltaTime);
    }
}
