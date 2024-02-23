using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            gameOverManager.Setup(other.gameObject.GetComponent<Player>());
        }
    }
}
